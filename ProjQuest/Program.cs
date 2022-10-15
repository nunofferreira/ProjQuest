using ProjQuest;
using System.Text.Json;

//string[] n = {"answer", "babana", "pear"};

////string n1 = n.SingleOrDefault(n => n.Length > 4);
////Console.WriteLine(n);



//QuestionSorting.CheckBoxQuestion();

//Console.WriteLine(n);

//foreach (string s in n)
//{
//    n.SingleOrDefault();
//    Console.WriteLine(n);
//}

//////////////////////////////////////

//var questions = new List<Question>();
//questions.Add(new Question("Can we obtain the array index using foreach loop in C#?", "No"));
//questions.Add(new Question("Which is the correct for() statement to run an infinite loop?", "for(;;)"));

////questions.Add()

////serializar
//var jsonQuestions = JsonSerializer.Serialize(questions, new JsonSerializerOptions()
//{
//    WriteIndented = true
//});


////File.WriteAllText("questions.json", jsonQuestions);

//jsonQuestions = File.ReadAllText("questions.json");
////descerializar
//var questionsList = JsonSerializer.Deserialize<List<Question>>(jsonQuestions);

Menus.Main();



Console.ReadLine();

