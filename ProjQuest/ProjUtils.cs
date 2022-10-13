namespace ProjQuest
{
    internal class ProjUtils
    {
        public static void EnableUTF8Encoding()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public static double ReadDouble(string message)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            double result;
            double.TryParse(str, out result);

            return result;
        }

        public static int ReadInt(string message)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            int result;
            int.TryParse(str, out result);

            return result;
        }

        public static int ReadChar(string message)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            char result;
            char.TryParse(str, out result);

            return result;
        }

    }
}
