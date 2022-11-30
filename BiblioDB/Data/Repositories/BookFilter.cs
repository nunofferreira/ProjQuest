namespace BiblioDB.Data.Repositories;

public class BookFilter
{
    public string Title { get; set; }
    public DateTime PublishYear { get; set; }
    public string UserId { get; set; }

    public BookFilter()
    {
        //PublishYear = null;
        Title = null;
        UserId = null;
    }
}
