namespace ProjQuest.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool HasApproval { get; set; }

    public Student(int id, string name, bool hasApproval)
    {
        Id = id;
        Name = name;
        HasApproval = hasApproval;
    }

    public static Student GreetAndCheck(DataBase dataBase)
    {
        Student student;

        Console.WriteLine("\n\tPlease write your name: ");
        string name = Console.ReadLine();
        if (!dataBase.Students.Exists(p => p.Name.Equals(name)))
        {
            student = new Student(1, "", false);
            student.Name = name;

            //Check for NULL Exception
            var lastStudent = dataBase.Students.OrderByDescending(p => p.Id).FirstOrDefault();
            if (lastStudent == null)
                student.Id = 1;
            else
                student.Id = lastStudent.Id + 1;

            dataBase.Students.Add(student);
        }
        else
            student = dataBase.Students.FirstOrDefault(p => p.Name.Equals(name));

        return student;
    }

    public void DoQuestionnaire(DataBase dataBase)
    {
        Questionnaire questionnaire = GetQuestionnaire(dataBase);

        int totalCorrect = 0;

        QuestResults questResult = new()
        {
            StudentId = Id,
            QuestId = questionnaire.Id,
            QuestDate = DateTime.Now,
        };

        foreach (var questId in questionnaire.QuestionIds)
        {
            Console.Clear();
            var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
            quest.PrintQuestions(false);

            int answer = ProjUtils.ReadInt("Your answer is: ");

            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);
            if (correctAnswer)
                totalCorrect++;

            questResult.Results.Add(new QuestResult(quest.Id, correctAnswer));
        }

        if (!this.HasApproval)
            this.HasApproval = totalCorrect / questionnaire.QuestionIds.Count > 0.8;

        //examResult.Results.Add(new ExamResult(quest.Id, correctAnswer));

        dataBase.QuestResults.Add(questResult);

        Console.Clear();

        //Shows the score
        var perc = (totalCorrect * 100) / questionnaire.QuestionIds.Count;
        Console.WriteLine($"\nScore: {totalCorrect} / {questionnaire.QuestionIds.Count} = {perc}%");

        if (perc > 79)
            Console.WriteLine("\nYou are now apt to do an exam");
        else
            Console.WriteLine("\nYou have to get at least 80% to be apt for an exam");

        Console.ReadLine();
    }

    private Questionnaire GetQuestionnaire(DataBase dataBase)
    {
        Questionnaire questionnaire = new();

        //Check for NULL Exception
        var lastQuestionnaire = dataBase.Questionnaires.OrderByDescending(p => p.Id).FirstOrDefault();
        if (lastQuestionnaire == null)
            questionnaire.Id = 1;
        else
            questionnaire.Id = lastQuestionnaire.Id + 1;

        questionnaire.StudentId = this.Id;

        List<int> selectedQuestionNumbers = new List<int>();

        var possibleQuestions = dataBase.Questions.Where(p => p.ExamOnly == false).ToList();

        for (int i = 0; i < 5; i++)
        {
            var nextQuestion = ProjUtils.RandomIgnoringNumbers(0, possibleQuestions.Count - 1, selectedQuestionNumbers);
            var question = possibleQuestions[nextQuestion];
            selectedQuestionNumbers.Add(nextQuestion);

            questionnaire.QuestionIds.Add(question.Id);
        }
        return questionnaire;
    }

    public void DoExam(DataBase dataBase)
    {
        var examList = dataBase.ExamList.Where(p => (p.StartingTime <= DateTime.Now &&
        p.AvailableUntil >= DateTime.Now)).ToList();
        
        //Check if there is any available exam for this time 
        if (examList == null || examList.Count == 0)
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine("There are no exams at this time!\n Please check the Time and date of Exam?");
            Console.ReadLine();
            return;
        }

        Exam exam = null;

        //Check if there is any available exam for this student 
        foreach (var selExam in examList)
        {
            if (selExam.StudentIds.Exists(p => p == this.Id))
                exam = selExam;
            break;
        }

        if (exam == null)
        {
            Console.WriteLine("There are no exams!\nHas the teacher made the exam available for you?");
            Console.ReadLine();

            return;
        }

        ExamResults examResult = new()
        {
            StudentId = Id,
            ExamId = exam.Id
        };

        List<int> questionsOnExam = new();
        for (int i = 0; i < exam.QuestionIds.Count; i++)
        {
            int nextQuestion = 0;

            //Check for repeat questions 
            if (exam.RandomQuests)
                nextQuestion = ProjUtils.RandomIgnoringNumbers(0, exam.QuestionIds.Count - 1, questionsOnExam);
            else
                nextQuestion = i;

            questionsOnExam.Add(nextQuestion);

            var quest = dataBase.Questions[nextQuestion];
            quest.PrintQuestions(false);

            int answer = ProjUtils.ReadInt("Your answer is: ");

            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);

            examResult.Results.Add(new ExamResult(quest.Id, correctAnswer));
        }

        dataBase.Results.Add(examResult);
    }

    public void PrintExamsDone(DataBase dataBase)
    {
        Console.Clear();

        var StudentResults = dataBase.Results.Where(s => s.StudentId == this.Id);
        foreach (var res in StudentResults)
        {
            foreach (var result in res.Results)
            {
                Console.WriteLine("-------------");
                var questId = result.QuestionId;
                var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
                Console.WriteLine($"{quest.Name} - {result.RightAnswer}");
            }
            Console.ReadLine();
        }
    }

    public void PrintQuestScore(DataBase dataBase)
    {
        Console.Clear();

        var StudentResults = dataBase.QuestResults.Where(s => s.StudentId == this.Id);
        Console.WriteLine("Score of all questionnaires taken:\n");

        foreach (var res in StudentResults)
        {
            int rightAnswers = res.Results.Where(p => p.RightAnswer).Count();
            int totalAnswers = res.Results.Count;

            var perc = (rightAnswers * 100) / totalAnswers;
            Console.WriteLine($"Date: {res.QuestDate.ToShortDateString()} {res.QuestDate.ToShortTimeString()}");
            Console.WriteLine($"Score: {rightAnswers}/{totalAnswers} = {perc}%");
            Console.WriteLine("--------------");
        }
        Console.ReadLine();
    }
}
