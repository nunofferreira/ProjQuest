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
}
