Console.WriteLine("Proj Dependency Injection");

var auth = new MemoryAuthenticator();
var autenticador = new Authenticator(auth);
var userIsAuthorised = autenticador.UserIsAuthorised("maria", "klwe");

Console.WriteLine(userIsAuthorised);


var auth1 = new FileAuthenticator();
autenticador = new Authenticator(auth1);
userIsAuthorised = autenticador.UserIsAuthorised("maria", "klwe");

Console.WriteLine(userIsAuthorised);