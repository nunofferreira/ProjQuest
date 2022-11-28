namespace BiblioDB.Data;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishYear { get; set; }

    public string UserId { get; set; }
    public IdentityUser? User { get; set; }
}
