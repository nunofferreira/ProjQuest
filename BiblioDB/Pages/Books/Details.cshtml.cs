namespace BiblioDB.Pages.Books;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly BiblioDB.Data.ApplicationDbContext _context;

    public DetailsModel(BiblioDB.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Book Book { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Books == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }
        return Page();
    }
}
