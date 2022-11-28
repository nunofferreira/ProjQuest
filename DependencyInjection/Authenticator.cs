
public class Authenticator
{
    private readonly IAuthenticator _autenticador;

    public Authenticator(IAuthenticator autenticador)
    {
        _autenticador = autenticador;
    }

    public bool UserIsAuthorised(string username, string password)
    {
        return _autenticador.Validate(username, password);
    }

}