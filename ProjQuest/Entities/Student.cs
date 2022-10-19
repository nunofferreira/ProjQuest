namespace ProjQuest.Entities;

internal class Student
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

    public static void GreetAndCheck()
    {
        Student student;
        DataBase dataBase = DataBase.LoadData();
        

        Console.WriteLine("\n\tPor favor digite o seu name: ");
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

        Console.WriteLine("\n\tOlá {0}", name);

        dataBase.SaveData();
    }
}
