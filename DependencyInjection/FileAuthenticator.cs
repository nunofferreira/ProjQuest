
public class FileAuthenticator : IAuthenticator
{
    public List<User> _users { get; set; }

    public FileAuthenticator()
    {

    }

    public FileAuthenticator(List<User> users)
    {
        _users = new List<User>()
        {
            new User("maria", "123"),
            new User("joana", "456"),
        };

        _users = users;

        var json = System.Text.Json.JsonSerializer.Serialize(users);


        File.WriteAllText("users.json", json);

        var newJson = File.ReadAllText("users.json");

        var newCar = System.Text.Json.JsonSerializer.Deserialize<User>(newJson);
        Console.WriteLine(newJson); 
    }

    public bool Validate(string username, string password)
        => _users.Any(x => x.UserName == username && x.Password == password);
}


