namespace ProjQuest.Entities;

public static class Teacher
{
    public static void CreateExam(DataBase dataBase)
    {
        Exam newExam = new();
       
        var lastExam = dataBase.ExamList.OrderByDescending(p => p.Id).FirstOrDefault();

        if (lastExam == null)
        {
            newExam.Id = 1;
        }
        else
        {
            newExam.Id = lastExam.Id + 1;
        }

        Console.WriteLine("\tExam name:");
        newExam.Name = Console.ReadLine();

        newExam.StartingTime = ProjUtils.ReadDatetime("Exam date: dd/MM/yyyy hh:mm");
        newExam.AvailableUntil = ProjUtils.ReadDatetime("Available until: dd/MM/yyyy hh:mm");

        var allQuestions = dataBase.Questions.Where(p => !p.ExamOnly);
        foreach (var question in allQuestions)
        {
            Console.WriteLine($"{question.Subject}{Environment.NewLine}{question.Name}");
            var answer = ProjUtils.ReadChar("Add this question? y-Yes; n-No");
            if (answer.Equals("y"))
            {
                newExam.QuestionIds.Add(question.Id);
            }
        }
        dataBase.ExamList.Add(newExam);
    }

    public static void CreateQuestion(DataBase dataBase)
    {
        Console.Clear();

        Question question = new();

        Console.WriteLine("\tInsert question");
        string name = Console.ReadLine();

        Console.WriteLine("\tWhat is the subject? \n1)C# basics \n2)Variables and Data Types \n3)Conditional and Control Statements");
        string subject = Console.ReadLine();

        Console.WriteLine("\tWhat is the dificulty level? \n1)Beginner \n2)Intermediate \n3)Advanced");
        string difLevel = Console.ReadLine();

        Console.WriteLine("\tInsert #Tag");
        string tag = Console.ReadLine();

        Console.WriteLine("\tType of question? \n1)CheckBox \n2)DropDown \n3)YesOrNo");
        string type = Console.ReadLine();

        Console.WriteLine("\tQuestion only to be used in exams? \n1)True \n2)False");
        bool examOnly = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));

        Console.WriteLine("\tWrite the possible answers");
        int numberOfAnswers = ProjUtils.ReadInt("\t\nHow many?");

        List<string> answersList = new();
        for (int i = 0; i < numberOfAnswers; i++)
        {
            Console.WriteLine($"\tWrite the answer number {i + 1}");
            answersList.Add(Console.ReadLine());
        }
        //string possAnswers = Console.ReadLine();

        Console.WriteLine("Write the position of the correct answer or answers, split by a comma (,)");
        string correctAnswer = Console.ReadLine(); //"1,2"
        var correctAnswerSplited = correctAnswer.Split(",");

        List<int> correctAnswerList = new();
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
        question.ExamOnly = examOnly;
        question.CorrectAnswer = correctAnswerList;
        question.PossAnswers = answersList;

        //Check for NULL Exception
        var lastQuestion = dataBase.Questions.OrderByDescending(p => p.Id).FirstOrDefault();
        if (lastQuestion == null)
        {
            question.Id = 1;
        }
        else
        {
            question.Id = lastQuestion.Id + 1;
        }

        dataBase.Questions.Add(question);
    }

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
                Console.WriteLine($"Question details: \nSubject: {quest.Subject} \nDificulty Level: {quest.DifLevel} " +
                    $"\nTag: {quest.Tag}\nType of question: {quest.Type}");

                Console.WriteLine();

                quest.PrintQuestions(true);
            }
            Console.WriteLine($"-------------------------\n");
        }
        Console.ReadLine();
    }

    public static void PrintGrades(DataBase dataBase)
    {
        Console.Clear();

        foreach (var resultExam in dataBase.Results.OrderBy(p => p.ExamId).ThenBy(p => p.StudentId))
        {
            var exam = dataBase.ExamList.FirstOrDefault(p => p.Id == resultExam.ExamId);
            var student = dataBase.Students.FirstOrDefault(p => p.Id == resultExam.StudentId);

            Console.WriteLine($"Exam name: {exam.Name}");
            Console.WriteLine($"Student name: {student.Name}");
            int rightAnswers = resultExam.Results.Where(p => p.RightAnswer).Count();
            int totalAnswers = resultExam.Results.Count;

            Console.WriteLine($"Grade: {rightAnswers}/{totalAnswers}");
            Console.WriteLine("");

            Console.WriteLine("____________________________");
            Console.WriteLine("");
        }
        Console.ReadLine();
    }
}
