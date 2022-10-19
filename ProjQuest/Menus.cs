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
        What would you like to do?

        1) Create an Exam
        2) Create Questions
        3) View Exams
        4) View Student Grades
        5) Exit";
        Console.WriteLine(menu_2);

        switch (Console.ReadLine())
        {
            case "1":
              Teacher.CreateExam();
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
        

        //while (menu2)
        //{ }

    }

    public static bool MenuStudent()
    {
        Console.Clear();
        Student student;
        student = new Student(1, "", true);
        Student.GreetAndCheck();
        //Console.WriteLine("\n\tPor favor digite o seu name: ");
        //string name = Console.ReadLine();
        //if (!dataBase.Students.Exists(p => p.Name.Equals(name)))
        //{
        //    student = new Student(1, "", true);
        //    student.Name = name;
        //    student.Id = dataBase.Students.Max(p => p.Id) + 1;

        //    dataBase.Students.Add(student);
        //}
        //else
        //{
        //    student = dataBase.Students.FirstOrDefault(p => p.Name.Equals(name));
        //}

        //Console.WriteLine("\n\tOlá {0}", name);
      
        var menu_3 = @"
        What would you like to do?

        1) Questionnaire
        2) Exam
        3) View all completed questionnaires
        4) View all completed tests
        5) Exit";
        Console.WriteLine(menu_3);
        switch (Console.ReadLine())
        {
            case "1":
                DoQuestionnaire();
                return true;
            case "2":
                if (student.HasApproval)
                {
                    DoExam();
                }
                else
                {
                    Console.Write("You have to get approval in the questionnaire first");
                    return false;
                }
                return true;
            case "3":
            SeeExamsDone();
            return true;
            case "4":
                SeeQuestionnairesDone();
                
                return true;
            case "5":
                return false;
            default:
                return true;
        }
    }

    
    private static void SeeExamsDone()
    {
        Student student;
        student = new Student(1, "", true);
        var StudentResults = dataBase.Results.Where(s => s.StudentId == student.Id);
        foreach (var res in StudentResults)
        {
            foreach (var quest in res.Results)
            {
                Console.WriteLine($"{quest.QuestionId}  {quest.RightAnwser}");
            }
        }
    }

    private static void SeeQuestionnairesDone()
    {
        Student student;
        student = new Student(1, "", true);
        var StudentResults = dataBase.Results.Where(s => s.StudentId == student.Id);
        foreach (var res in StudentResults)
        {
            foreach (var quest in res.Results)
            {
                Console.WriteLine($"{quest.QuestionId}  {quest.RightAnwser}");
            }
        }
    }

    //public static void CreateExam()
    //{
    //    Exam newExam = new Exam();
    //    Console.WriteLine("\tExam name:");
    //    newExam.Name = Console.ReadLine();

    //    newExam.StartingTime = ProjUtils.ReadDatetime("Exam date: dd/MM/yyyy hh:mm");
    //    newExam.AvailablePeriod = ProjUtils.ReadDatetime("Available until: dd/MM/yyyy hh:mm");

    //    var allQuestions = dataBase.Questions.Where(q => q.OnlyTest);
    //    foreach (var question in allQuestions)
    //    {
    //        Console.WriteLine($"{question.Subject}{Environment.NewLine}{question.Name}");
    //        Console.WriteLine("Add this question? y-Yes; n-No");
    //        var answer = Console.ReadLine();
    //        if (answer.Equals("y"))
    //        {
    //            newExam.QuestionIds.Add(question.Id);
    //        }
    //    }
    //    dataBase.ExamList.Add(newExam);
    //}

    private static void CreateQuestion()
    {
        Question question;
        question = new Question();

        Console.WriteLine("\tInsert question");
        string name = Console.ReadLine();

        Console.WriteLine("\tWhat is the subject? \n1)C# basics \n2)Variables and Data Types \n3)Conditional and Control Statements");
        string subject = Console.ReadLine();

        Console.WriteLine("\tWhat is the dificulty level? \n1)Beginner \n2)Intermediate \n3)Advanced");
        string difLevel = Console.ReadLine();

        Console.WriteLine("Insert #Tag");
        string tag = Console.ReadLine();

        Console.WriteLine("Type of question? \n1)CheckBox \n2)DropDown \n3)YesOrNo");
        string type = Console.ReadLine();

        Console.WriteLine("Question only to be used in tests? \nTrue \n2)False");
        bool onlyTest = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Write the correct answer");
        string correctAnswer = Console.ReadLine();

        Console.WriteLine("Write the possible answers");
        string possAnswers = Console.ReadLine();

        Console.WriteLine("");
        question.Name = name;
        question.Subject = subject;
        question.DifLevel = difLevel;
        question.Tag = tag;
        question.Type = type;
        question.OnlyTest = onlyTest;
        //question.CorrectAnswer = correctAnswer;
        //question.PossAnswers = possAnswers;


        question.Id = dataBase.Questions.Max(q => q.Id) + 1;

        dataBase.Questions.Add(question);

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
