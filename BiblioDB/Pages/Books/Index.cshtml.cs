namespace BiblioDB.Pages.Books;

[Authorize]
public class IndexModel : PageModel
{
    private readonly BiblioDB.Data.ApplicationDbContext _context;

    public IndexModel(BiblioDB.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Book> Book { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Books != null)
        {
            Book = await _context.Books
            .Include(b => b.User).ToListAsync();
        }
    }
}
