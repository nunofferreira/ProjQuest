namespace BiblioDB.Pages.Books;

[Authorize]
public class CreateModel : PageModel
{
    private readonly BiblioDB.Data.ApplicationDbContext _context;

    public CreateModel(BiblioDB.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; }
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        Book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Books.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
