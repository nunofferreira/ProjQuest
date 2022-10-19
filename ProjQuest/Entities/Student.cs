namespace ProjQuest.Entities;

public class Student
{
    //visualizar todos os testes e questionarios (só a nota) feitos por ele 
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
            student.Id = dataBase.Students.Max(p => p.Id) + 1;

            dataBase.Students.Add(student);
        }
        else
        {
            student = dataBase.Students.FirstOrDefault(p => p.Name.Equals(name));
        }

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
            quest.PrintQuestions(true);

            int answer = ProjUtils.ReadInt("Your answer is: ");
            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);
            if(correctAnswer)
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

        questionnaire.Id = lastQuestionnaire == null ? 1: lastQuestionnaire.Id + 1;
        questionnaire.StudentId = this.Id;
        Random rnd = new Random();

        var possibleQuestions = dataBase.Questions.Where(p => p.OnlyTest == false).ToList();

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
        Exam exam = dataBase.ExamList.Where(p=>(p.StartingTime <= DateTime.Now && p.StartingTime.AddHours(1)> DateTime.Now)).FirstOrDefault();

        if(exam== null)
        {
            Console.WriteLine("There are no exams");
            return;
        }
        ExamResults examResult = new ExamResults();
        examResult.StudentId = this.Id;
        examResult.ExamId = exam.Id;

        foreach (var questId in exam.QuestionIds)
        {
            var quest = dataBase.Questions.FirstOrDefault(p => p.Id == questId);
            quest.PrintQuestions(true);

            int answer = ProjUtils.ReadInt("Your answer is: ");
            bool correctAnswer = quest.CorrectAnswer.Any(p => p == answer);

            examResult.Results.Add(new (questId, correctAnswer));
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

    //public static void PrintQuestionnairesDone(DataBase dataBase)
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
