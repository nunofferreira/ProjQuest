namespace ProjQuest;

public static class Menus
{
    public static void Main()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = FirstScreen();
        }
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

    public static void MenuTeacher()
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
            //case "1":
            //    //CreateExam();
            //   // return true;
            //case "2":
            //    //CreateQuestion();
            //    //return true;
            //case "3":
            //    //SeeExams();
            //    //return true;
            //case "4":
            ////SeeGrades();
            //default:
            //    return true;
        }


        //while (menu1)
        //{ }
    }

    public static void MenuStudent()
    {
        Console.Clear();

        Console.WriteLine("\n\tPor favor digite o seu nome: ");
        string nome = Console.ReadLine();
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
            //case "1":
            //    //DoQuestionnaire();
            //   // return true;
            //case "2":
            //    //DoExam();
            //    //return true;
            //case "3":
            //    //SeeExamsDone();
            //    //return true;
            //case "4":
            //    //SeeQuestionnairesDone();
            //      //return true
            //default:
            //    return true;
        }
    }

    private static void ShowMenu()
    {
        var menu = @"
1

















";
    }

}
