public interface IAuthenticator
{
    bool Validate(string username, string password);
}
