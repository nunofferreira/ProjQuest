﻿namespace BiblioDB.Pages.Books;

[Authorize]
public class EditModel : PageModel
{
    private readonly BiblioDB.Data.ApplicationDbContext _context;

    public EditModel(BiblioDB.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Books == null)
        {
            return NotFound();
        }

        var book =  await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        Book = book;
       ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(Book.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool BookExists(int id)
    {
      return _context.Books.Any(e => e.Id == id);
    }
}
