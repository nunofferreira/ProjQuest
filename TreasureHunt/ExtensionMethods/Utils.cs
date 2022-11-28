// Como usar
// var matricula = "aa-11-Bb";
// Utils.Formatar(matricula);
// ou
// matricula.Formatar();


// métodos idênticos
public static class Utils
{
    public static string Formatar(this string matricula)
    {
        return matricula.Replace("-", "").ToUpper();
    }
}

