using ProjQuest;
using ProjQuest.Entities;
using System.Text.Json;



//var students = new List<Student>();
//students.Add(new Student(1, "Nuno", true));

//var jsonDataBase = JsonSerializer.Serialize(students, new JsonSerializerOptions()
//{
//    WriteIndented = true
//});
//File.WriteAllText("Database.json", jsonDataBase);

//ProjUtils.CreateGuid(args);

Menus.StartProgram();
//Console.WriteLine(" _______  _______ _________ _             \r\n(  ____ \\(       )\\__   __/( \\   |\\     /|\r\n| (    \\/| () () |   ) (   | (   ( \\   / )\r\n| (__    | || || |   | |   | |    \\ (_) / \r\n|  __)   | |(_)| |   | |   | |     \\   /  \r\n| (      | |   | |   | |   | |      ) (   \r\n| (____/\\| )   ( |___) (___| (____/\\| |   \r\n(_______/|/     \\|\\_______/(_______/\\_/   \r\n                                         ");
Console.ReadLine();

Console.WriteLine(QuestionSorting.GetQuestion(5)  ); 
