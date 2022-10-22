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
        2) Create a Question
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
                    return;
                default:
                    return;
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
        3) View all completed Exams
        4) View Questionnaire scores
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
                        student.DoExam(dataBase);
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("You have to get approval in the questionnaire first!");
                        Console.ReadLine();
                    }
                    break;
                case "3":
                    student.PrintExamsDone(dataBase);
                    break;
                case "4":
                    student.PrintQuestScore(dataBase);
                    break;
                case "5":
                    return;
                default:
                    return;
            }
        }
    }
}
