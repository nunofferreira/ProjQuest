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
            student = new Student(1, "", true);
            student.Name = name;

            //TODO: Check NULL
            student.Id = dataBase.Students.Max(p => p.Id) + 1;

            dataBase.Students.Add(student);
        }
        else
        {
            student = dataBase.Students.FirstOrDefault(p => p.Name.Equals(name));
        }

        Console.Clear();
        Console.WriteLine("\n\tHello {0}!", name);
        return student;
    }

    public void DoQuestionnaire(DataBase dataBase)
    {
        Questionnaire questionnaire = GetQuestionnaire(dataBase);
        int totalCorrect = 0;

        foreach (var questId in questionnaire.QuestionIds)
        {
            var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
            quest.PrintQuestions(false);

            int answer = ProjUtils.ReadInt("Your answer is: ");
            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);
            if (correctAnswer)
            {
                totalCorrect++;
            }
        }
        if (!this.HasApproval)
        {
            this.HasApproval = totalCorrect / questionnaire.QuestionIds.Count() > 0.8;
        }
    }

    private Questionnaire GetQuestionnaire(DataBase dataBase)
    {
        Questionnaire questionnaire = new Questionnaire();
        var lastQuestionnaire = dataBase.Questionnaires.OrderByDescending(p => p.Id).FirstOrDefault();

        questionnaire.Id = lastQuestionnaire == null ? 1 : lastQuestionnaire.Id + 1;
        questionnaire.StudentId = this.Id;
        Random rnd = new Random();

        var possibleQuestions = dataBase.Questions.Where(p => p.ExamOnly == false).ToList();

        for (int i = 0; i < 5; i++)
        {
            var nextQuestion = rnd.Next(0, possibleQuestions.Count() - 1);
            var question = possibleQuestions[nextQuestion];

            questionnaire.QuestionIds.Add(question.Id);
        }

        return questionnaire;
    }

    public void DoExam(DataBase dataBase)
    {
        Exam exam = dataBase.ExamList.Where(p => (p.StartingTime <= DateTime.Now && 
        p.StartingTime.AddHours(1) > DateTime.Now)).FirstOrDefault();

        if (exam == null)
        {
            Console.Clear();
            //Console.Beep();
            Console.WriteLine("There are no exams!\nPlease check the requirements:\n\nOver 80% in a questionnaire?" +
                "\nTime and date of Exam? \nHas the teacher made the exam available for you?");
            Console.ReadLine();
            return;
        }

        ExamResults examResult = new ExamResults();
        //var lastExamResult = dataBase.Results.OrderByDescending(p => p.ExamId).FirstOrDefault();

        //examResult.ExamId = lastExamResult == null ? 1 : lastExamResult.ExamId + 1;

        examResult.StudentId = this.Id;
        examResult.ExamId = exam.Id;

        foreach (var questId in exam.QuestionIds)
        {
            var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
            quest.PrintQuestions(false);

            int answer = ProjUtils.ReadInt("Your answer is: ");
            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);

            //TODO: Check Null 
            examResult.Results.Add(new(questId, correctAnswer));
        }

        dataBase.Results.Add(examResult);
    }

    public void PrintExamsDone(DataBase dataBase)
    {

        var StudentResults = dataBase.Results.Where(s => s.StudentId == this.Id);
        foreach (var res in StudentResults)
        {
            foreach (var result in res.Results)
            {
                var questId = result.QuestionId;
                var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
                Console.WriteLine($"{quest.Name} - {result.RightAnswer}");
            }
        }
    }
}
