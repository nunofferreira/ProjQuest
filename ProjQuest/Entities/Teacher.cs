namespace ProjQuest.Entities;

public static class Teacher
{
    //criar testes e questoes
    public static void CreateExam()
    {
        DataBase dataBase = DataBase.LoadData();
        Exam newExam = new Exam();
        Console.WriteLine("\tExam name:");
        newExam.Name = Console.ReadLine();

        newExam.StartingTime = ProjUtils.ReadDatetime("Exam date: dd/MM/yyyy hh:mm");
        newExam.AvailablePeriod = ProjUtils.ReadDatetime("Available until: dd/MM/yyyy hh:mm");

        var allQuestions = dataBase.Questions.Where(q => q.OnlyTest);
        foreach (var question in allQuestions)
        {
            Console.WriteLine($"{question.Subject}{Environment.NewLine}{question.Name}");
            Console.WriteLine("Add this question? y-Yes; n-No");
            var answer = Console.ReadLine();
            if (answer.Equals("y"))
            {
                newExam.QuestionIds.Add(question.Id);
            }
        }
        dataBase.ExamList.Add(newExam);

        dataBase.SaveData();
    }
    //visualizar todos os testes e notas dos alunos 
}
