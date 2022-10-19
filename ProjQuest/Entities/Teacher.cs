using System.ComponentModel;

namespace ProjQuest.Entities;

public static class Teacher
{
    //criar testes e questoes
    public static void CreateExam(DataBase dataBase)
    {
        Exam newExam = new Exam();
        newExam.Id = dataBase.ExamList.Max(p => p.Id) + 1;

        Console.WriteLine("\tExam name:");
        newExam.Name = Console.ReadLine();

        newExam.StartingTime = ProjUtils.ReadDatetime("Exam date: dd/MM/yyyy hh:mm");
        newExam.AvailableUntil = ProjUtils.ReadDatetime("Available until: dd/MM/yyyy hh:mm");

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
    }

    public static void CreateQuestion(DataBase dataBase)
    {
        Question 
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

        Console.WriteLine("Write the possible answers");
        int numberOfAwnsers = ProjUtils.ReadInt("How many?");

        List<string> answersList = new List<string>();
        for (int i = 0; i < numberOfAwnsers; i++)
        {
            Console.WriteLine($"Write the answer number {i+1}");
            answersList.Add(Console.ReadLine());

        }
        string possAnswers = Console.ReadLine();
        
        Console.WriteLine("Write the correct answer or answers, split by (,)");
        string correctAnswer = Console.ReadLine(); //"1,2"
        var correctAnswerSplited = correctAnswer.Split(",");
        
        List<int> correctAnswerList = new List<int>();
        foreach (var item in correctAnswerSplited)
        {
            correctAnswerList.Add(Convert.ToInt32(item));
        }

        Console.WriteLine("");
        question.Name = name;
        question.Subject = subject;
        question.DifLevel = difLevel;
        question.Tag = tag;
        question.Type = type;
        question.OnlyTest = onlyTest;
        question.CorrectAnswer = correctAnswerList;
        question.PossAnswers = answersList;


        question.Id = dataBase.Questions.Max(q => q.Id) + 1;

        dataBase.Questions.Add(question);

    }
    //visualizar todos os testes e notas dos alunos 

    public static void PrintExams(DataBase dataBase)
    {
        Console.Clear();

        foreach (var exam in dataBase.ExamList)
        {
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"Exam name:{exam.Name}");
            Console.WriteLine($"-------------------------");

            foreach (var question in exam.QuestionIds)
            {
                var quest = dataBase.Questions.FirstOrDefault(p => p.Id == question);
                Console.WriteLine(quest.Name);
                Console.WriteLine(quest.Subject);
                Console.WriteLine();

                quest.PrintQuestions(true);

                //Print details of question
            }
            Console.WriteLine($"-------------------------");
        }

        Console.ReadLine();
    }

    public static void PrintGrades(DataBase dataBase)
    {
        Console.Clear();

        foreach (var resultExam in dataBase.Results.OrderBy(p=>p.ExamId).ThenBy(p=>p.StudentId))
        {
            var exam = dataBase.ExamList.FirstOrDefault(p => p.Id == resultExam.ExamId);
            var student = dataBase.Students.FirstOrDefault(p => p.Id == resultExam.StudentId);

            Console.WriteLine($"Exam name: {exam.Name}");
            Console.WriteLine($"Student name: {student.Name}");

            foreach (var result in resultExam.Results)
            {
                var quest = dataBase.Questions.FirstOrDefault(p => p.Id == result.QuestionId);
                Console.WriteLine($"{quest.Name} - {result.RightAnswer}");
            }

            Console.WriteLine("____________________________");
            Console.WriteLine("");

        }
    }
}
