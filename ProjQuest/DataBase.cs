using System.Text.Json;
using ProjQuest.Entities;

namespace ProjQuest;

internal class DataBase
{
    public List<Exam> ListaExames { get; set; }
    public List<Student> Alunos { get; set; }
    public List<ExamResults> Results { get; set; }
    public List<Question> Questions { get; set; }

    public DataBase()
    {
        ListaExames = new List<Exam>();
        Alunos = new List<Student>();
        Results = new List<ExamResults>();
        Questions = new List<Question>();
    }

    private static string GetPath()
    {
        string path = Environment.CurrentDirectory.Replace(Path.GetRelativePath("../../..", Environment.CurrentDirectory), "");
        path = Path.Combine(path, "DataBase/", "DataBase.json");

        return path;
    }

    internal static DataBase LoadData()
    {
        DataBase data = new DataBase();
              
        var jsonQuestions = File.ReadAllText(GetPath());
       
        data = JsonSerializer.Deserialize<DataBase>(jsonQuestions);

        return data;
    }

    internal void SaveData()
    {
        var jsonQuestions = JsonSerializer.Serialize(this, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        File.WriteAllText(GetPath(), jsonQuestions);
    }
}


