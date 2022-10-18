namespace ProjQuest.Entities;

static class QuestionSorting
{
    static Random rnd = new();

    static List<Question> checkBox = new();

    //public static void CheckBox()
    //{

    //}

    static List<Question> dropDown = new();

    //public static void DropDown()
    //{
    //    string q = "";  

    //    q.SingleOrDefault();
    //}

    static List<Question> YesOrNo = new();

    //public static void YesOrNo()
    //{

    //}
   
    internal static List<Question> GetQuestion(int questionsNum)
    {
        List<Question> questions = new();

        for (int i = 0; i < questionsNum; i++)
        {
            //var getCheckBox = checkBox < rnd.Next(checkBox.Count) >;
            //var getdropDown = dropDown < rnd.Next(dropDown.Count)>;
            //var getYesOrNo = yesOrNo < rnd.Next(yesOrNo.Count)>;

            //questions[i] = new Question();

            int rnd = QuestionSorting.rnd.Next();

            Question question = new Question();
            questions.Add(question);
        }
        return questions;
    }
}
