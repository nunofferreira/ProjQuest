using ProjQuest.Entities;
namespace ProjQuest;

public static class Menus
{
    private static DataBase dataBase;
    public static void StartProgram()
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
        ProjUtils.PrintLogo();

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

    public static void MenuTeacher()
    {
        while (true)
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
                    Teacher.CreateExam(dataBase);
                    break;
                case "2":
                    Teacher.CreateQuestion(dataBase);
                    break;
                case "3":
                    Teacher.PrintExams(dataBase);
                    break;
                case "4":
                    Teacher.PrintGrades(dataBase);
                    break;
                case "5":
                    return ;
                default:
                    return ;
            }
        }
    }

    public static void MenuStudent()
    {
        while (true)
        {


            Console.Clear();

            Student student = Student.GreetAndCheck(dataBase);

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
                    student.DoQuestionnaire(dataBase);
                    break;
                case "2":
                    if (student.HasApproval)
                    {
                        Student.DoExam(dataBase);
                    }
                    else
                    {
                        Console.Write("You have to get approval in the questionnaire first");
                    }
                    break;
                case "3":
                    Student.PrintExamsDone(dataBase);
                    break;
                case "4":
                    Student.PrintQuestionnairesDone(dataBase);

                    break;
                case "5":
                    return ;
                default:
                    return ;
            }
        }
    }



    //private static void DoQuestionnaire()
    //{
    //    Question quest = new Question();

    //    DataBase dataBase = new DataBase();

    //    var questionnaire = dataBase.Questions.Where(q => q.Id == quest.Id);

    //    foreach (var ques in questionnaire)
    //    {
    //        foreach (var answer in ques.PossAnswers)
    //        {
    //            Console.WriteLine($"{quest.Name} {quest.PossAnswers}");
    //        }
    //    }
    //}

    //private static void DoExam()
    //{

    //}
    //private static void PrintExamsDone()
    //{
    //    Student student;
    //    student = new Student(1, "", true);
    //    var StudentResults = dataBase.Results.Where(s => s.StudentId == student.Id);
    //    foreach (var res in StudentResults)
    //    {
    //        foreach (var quest in res.Results)
    //        {
    //            Console.WriteLine($"{quest.QuestionId} {quest.RightAnswer}");
    //        }
    //    }
    //}

    //private static void PrintQuestionnairesDone()
    //{
    //    Student student;
    //    student = new Student(1, "", true);
    //    var StudentResults = dataBase.Results.Where(s => s.StudentId == student.Id);
    //    foreach (var res in StudentResults)
    //    {
    //        foreach (var quest in res.Results)
    //        {
    //            Console.WriteLine($"{quest.QuestionId} {quest.RightAnswer}");
    //        }
    //    }
    //}  
}
