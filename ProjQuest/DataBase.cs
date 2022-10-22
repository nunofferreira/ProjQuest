using System.Text.Json;
using ProjQuest.Entities;

namespace ProjQuest;

public class DataBase
{
    public List<Exam> ExamList { get; set; }
    public List<Student> Students { get; set; }
    public List<ExamResults> Results { get; set; }
    public List<Question> Questions { get; set; }
    public List<Questionnaire> Questionnaires { get; set; }
    public List <QuestResults> QuestResults { get; set; }

    public DataBase()
    {
        ExamList = new List<Exam>();
        Students = new List<Student>();
        Results = new List<ExamResults>();
        Questions = new List<Question>();
        Questionnaires = new List<Questionnaire>();
        QuestResults = new List<QuestResults>();
    }

    private static string GetPath()
    {
        string path = Environment.CurrentDirectory.Replace(Path.GetRelativePath("../../..", Environment.CurrentDirectory), "");
        path = Path.Combine(path, "DataBase/", "DataBase.json");

        return path;
    }

    public static DataBase LoadData()
    {
        DataBase data = new();
              
        var jsonDataBase = File.ReadAllText(GetPath());
       
        data = JsonSerializer.Deserialize<DataBase>(jsonDataBase);

        return data;
    }

    public void SaveData()
    {
        var jsonDataBase = JsonSerializer.Serialize(this, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        File.WriteAllText(GetPath(), jsonDataBase);
    }
}


