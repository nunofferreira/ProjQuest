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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (_context.Books != null)
        {
            Book = await _context.Books
            .Where(b => b.UserId == userId).ToListAsync();

            ////Faz o mesmo que o código acima
            //var books = await (from book in _context.Books
            //            where book.UserId == userId
            //            select book).ToListAsync();
        }
    }

    public String nameFilter { get; set; } 

    public async Task OnPostAsync(BookRepository bookRepo)
    {
        var filter = new BookFilter();
        filter.Title = nameFilter;

        Book = await bookRepo.FindByFilterAsync(filter);
    }
}
