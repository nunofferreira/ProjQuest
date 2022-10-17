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

        //bool showMenu1 = true;
        //while (showMenu1)
        //{
        //    showMenu1 = MenuTeacher();
        //}

        dataBase.SaveData();
    }

    public static bool FirstScreen()
    {
        Console.Clear();

        var menu_1 = @"
        **BEM VINDO AO QUEST**
     
        Digite a sua opção por favor: 
     
        1) Professor
        2) Aluno
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
        3) Visualizar notas dos alunos";
        Console.WriteLine(menu_2);

        switch (Console.ReadLine())
        {
            case "1":
                CreateExam();
                return true;
            //case "2":
            //    CreateQuestion();
            //    return true;
            //case "3":
            //    SeeExams();
            //    return true;
            //case "4":
            //    SeeGrades();
            //    return true;
            default:
                return true;
        }

        //while (menu2)
        //{ }
    }

    public static bool MenuStudent()
    {
        Console.Clear();
        Student aluno;

        Console.WriteLine("\n\tPor favor digite o seu nome: ");
        string nome = Console.ReadLine();
        if (!dataBase.Alunos.Exists(p => p.Name.Equals(nome)))
        {
            aluno = new Student();
            aluno.Name = nome;
            aluno.Id = dataBase.Alunos.Max(p => p.Id) + 1;

            dataBase.Alunos.Add(aluno);
        }
        else
        {
            aluno = dataBase.Alunos.FirstOrDefault(p => p.Name.Equals(nome));
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

                }
                else
                {
                    Console.Write("Tens que fazer o questionário com aprovação.");
                    return false;

                }
                //    //DoExam();
                return true;
            //case "3":
            //    //SeeExamsDone();
            //    //return true;
            case "4":
                //    //SeeQuestionnairesDone();
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
        Console.WriteLine("Nome do exame");
        newExam.Name = Console.ReadLine();

        newExam.AvailablePeriod = ProjUtils.ReadDatetime("Data do Exame: dd/MM/yyyy hh:mm");
        var allQuestions = dataBase.Questions.Where(p => p.OnlyTest);
        foreach (var question in allQuestions)
        {
            Console.WriteLine($"{question.Assunto}{Environment.NewLine}{question.Nome}");
            Console.WriteLine("Adicionar pergunta? s-Sim; n-Não");
            var resposta = Console.ReadLine();
            if (resposta.Equals("s"))
            {
                newExam.QuestionIds.Add(question.Id);
            }
        }
        dataBase.ListaExames.Add(newExam);
    }

    private static void CreateQuestion()
    {
        Question newQuestion = new Question();
        Console.WriteLine("Inserir a pergunta");
        newQuestion.Nome = Console.ReadLine();

    }

    private static void DoQuestionnaire()
    {
        //Questionnaires quest = new Questionnaires();


        //dataBase
    }

}
