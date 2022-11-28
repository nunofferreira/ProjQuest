
public class MemoryAuthenticator : IAuthenticator
{
    private List<User> _users;

    public MemoryAuthenticator()
    {
        _users = new List<User>()
        {
            new User("maria", "123"),
            new User("joana", "456"),
        };
    }

    public bool Validate(string username, string password)
        => _users.Any(x => x.UserName == username && x.Password == password);
}
