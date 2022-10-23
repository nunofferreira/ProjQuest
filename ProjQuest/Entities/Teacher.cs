namespace ProjQuest.Entities;

public static class Teacher
{
    public static void CreateExam(DataBase dataBase)
    {
        Console.Clear();

        Exam newExam = new();

        //Check for NULL Exception
        var lastExam = dataBase.ExamList.OrderByDescending(p => p.Id).FirstOrDefault();
        if (lastExam == null)
        {
            newExam.Id = 1;
        }
        else
        {
            newExam.Id = lastExam.Id + 1;
        }

        Console.WriteLine("\t\nExam's name:");
        newExam.Name = Console.ReadLine();

        newExam.StartingTime = ProjUtils.ReadDatetime("\t\nExam date: dd/MM/yyyy hh:mm");
        newExam.AvailableUntil = ProjUtils.ReadDatetime("\t\nAvailable until: dd/MM/yyyy hh:mm");

        var answerRnd = ProjUtils.ReadChar("Do you want random questions? y-Yes; n-No");
        if (answerRnd.Equals('y'))
        {
            newExam.RandomQuests = true;
        }

        Console.WriteLine("\nPlease choose the students that will take part in the exam:");
        var allStudents = dataBase.Students.Where(p => p.HasApproval);
        foreach (var student in allStudents)
        {
            Console.WriteLine($"\n{student.Name}");
            var reply = ProjUtils.ReadChar("Add this student? y-Yes; n-No");
            if (reply.Equals('y'))
            {
                newExam.StudentIds.Add(student.Id);
            }
        }
        Console.Clear();

        var allQuestions = dataBase.Questions;
        foreach (var question in allQuestions)
        {
            Console.WriteLine($"{question.Subject}\n{question.Name}");
            var answer = ProjUtils.ReadChar("Add this question? y-Yes; n-No");
            if (answer.Equals('y'))
            {
                newExam.QuestionIds.Add(question.Id);
            }
        }
        Console.Clear();
        Console.WriteLine($"The Exam '{newExam.Name}' is ready!\nPlease exit the program to save.");
        Console.ReadLine();

        dataBase.ExamList.Add(newExam);
    }

    public static void CreateQuestion(DataBase dataBase)
    {
        Console.Clear();

        Question question = new();

        Console.WriteLine("\tInsert question");
        question.Name = Console.ReadLine();

        Console.WriteLine("\tWhat is the subject? \n1)C# basics \n2)Variables and Data Types \n3)Conditional and Control Statements");
        question.Subject = Console.ReadLine();

        Console.WriteLine("\tWhat is the dificulty level? \n1)Beginner \n2)Intermediate \n3)Advanced");
        question.DifLevel = Console.ReadLine();

        Console.WriteLine("\tInsert #Tag");
        question.Tag = Console.ReadLine();

        Console.WriteLine("\tType of question? \n1)CheckBox \n2)DropDown \n3)YesOrNo");
        question.Type = Console.ReadLine();

        Console.WriteLine("\tQuestion only to be used in exams? \n1)True \n2)False");
        question.ExamOnly = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));

        Console.WriteLine("\tWrite the possible answers");
        int numberOfAnswers = ProjUtils.ReadInt("\t\nHow many?");

        List<string> answersList = new();
        for (int i = 0; i < numberOfAnswers; i++)
        {
            Console.WriteLine($"\tWrite the answer number {i + 1}");
            answersList.Add(Console.ReadLine());
        }

        Console.WriteLine("Write the position of the correct answer or answers, split by a comma (,)");
        string correctAnswer = Console.ReadLine(); //"1,2"
        var correctAnswerSplited = correctAnswer.Split(",");

        List<int> correctAnswerList = new();
        foreach (var item in correctAnswerSplited)
        {
            correctAnswerList.Add(Convert.ToInt32(item));
        }

        Console.WriteLine("");
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
