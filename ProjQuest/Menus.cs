using ProjQuest.Entities;
namespace ProjQuest;

public static class Menus
{
    private static DataBase dataBase;
    public static void Main()
    {
        dataBase = DataBase.LoadData();

        bool showMenu = true;
        while (showMenu)
        {
            showMenu = FirstScreen();
        }

        dataBase.SaveData();
    }

    public static bool FirstScreen()
    {
        Console.Clear();
        PrintLogo();

        var menu_1 = @"
            **WELCOME TO QUEST**
     
        Please select from the below: 
     
        1) Teacher
        2) Student
        3) Exit";
        Console.WriteLine(menu_1);

        switch (Console.ReadLine())
        {
            case "1":
                MenuTeacher();
                return true;
            case "2":
                MenuStudent();
                return true;
            case "3":
                return false;
            default:
                return true;
        }
    }

    public static bool MenuTeacher()
    {
        Console.Clear();



        var menu_2 = @"
        O que pretende fazer?

        1) Criar testes
        2) Criar questões
        3) Visualizar testes
        4) Visualizar notas dos alunos
        5) Exit";
        Console.WriteLine(menu_2);

        switch (Console.ReadLine())
        {
            case "1":
                CreateExam();
                return true;
            case "2":
                CreateQuestion();
                return true;
            case "3":
                //    SeeExams();
                return true;
            case "4":
                //    SeeGrades();
                return true;
            case "5":
                return false;
            default:
                return true;
        }
        return true;

        //while (menu2)
        //{ }

    }

    public static bool MenuStudent()
    {
        Console.Clear();
        Student aluno;

        Console.WriteLine("\n\tPor favor digite o seu nome: ");
        string nome = Console.ReadLine();
        if (!dataBase.Students.Exists(p => p.Name.Equals(nome)))
        {
            aluno = new Student(1, "", true);
            aluno.Name = nome;
            aluno.Id = dataBase.Students.Max(p => p.Id) + 1;

            dataBase.Students.Add(aluno);
        }
        else
        {
            aluno = dataBase.Students.FirstOrDefault(p => p.Name.Equals(nome));
        }

        Console.WriteLine("\n\tOlá {0}", nome);

        var menu_3 = @"
        O que pretende fazer?

        1) Fazer questionário
        2) Fazer teste
        3) Visualizar questionários efetuados
        3) Visualizar testes efetuados";
        Console.WriteLine(menu_3);
        switch (Console.ReadLine())
        {
            case "1":
                DoQuestionnaire();
                return true;
            case "2":
                if (aluno.HasApproval)
                {
                    DoExam();
                }
                else
                {
                    Console.Write("Tens que fazer o questionário com aprovação.");
                    return false;
                }
                return true;
            //case "3":
            //    //SeeExamsDone();
            //    //return true;
            case "4":
                //SeeQuestionnairesDone();
                var resultadosAluno = dataBase.Results.Where(p => p.AlunoId == aluno.Id);
                foreach (var res in resultadosAluno)
                {
                    foreach (var quest in res.Results)
                    {
                        Console.WriteLine($"{quest.QuestionId}  {quest.RightAnwser}");
                    }
                }
                return true;
            default:
                return true;
        }
    }

    private static void CreateExam()
    {
        Exam newExam = new Exam();
        Console.WriteLine("\tExam name:");
        newExam.Name = Console.ReadLine();

        newExam.StartingTime = ProjUtils.ReadDatetime("Exam date: dd/MM/yyyy hh:mm");
        newExam.AvailablePeriod = ProjUtils.ReadDatetime("Available until: dd/MM/yyyy hh:mm");

        //implementar tambem o periodo do exame ou data de fim

        var allQuestions = dataBase.Questions.Where(p => p.OnlyTest);
        foreach (var question in allQuestions)
        {
            Console.WriteLine($"{question.Subjet}{Environment.NewLine}{question.Name}");
            Console.WriteLine("Adicionar esta pergunta? s-Sim; n-Não");
            var resposta = Console.ReadLine();
            if (resposta.Equals("s"))
            {
                newExam.QuestionIds.Add(question.Id);
            }
        }
        dataBase.ExamList.Add(newExam);
    }

    private static void CreateQuestion()
    {
        Question newQuestion = new Question();
        Console.WriteLine("\tInserir a pergunta");
        newQuestion.Name = Console.ReadLine();

        dataBase.Questions.Add(newQuestion);

    }

    private static void DoQuestionnaire()
    {
        //Questionnaires quest = new Questionnaires();


        //dataBase
    }

    private static void DoExam()
    {

    }

    private static void PrintLogo()
    {
        Console.WriteLine(@"
           ____                  _   
          / __ \                | |  
         | |  | |_   _  ___  ___| |_ 
         | |  | | | | |/ _ \/ __| __|
         | |__| | |_| |  __/\__ \ |_ 
          \___\_\\__,_|\___||___/\__|
                            ");
    }
}
