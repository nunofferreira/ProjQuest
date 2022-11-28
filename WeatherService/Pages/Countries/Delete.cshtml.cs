namespace WeatherService.Pages.Countries;

public class DeleteModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public DeleteModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Country Country { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Countries == null)
        {
            return NotFound();
        }

        var country = await _context.Countries.FirstOrDefaultAsync(m => m.Id == id);

        if (country == null)
        {
            return NotFound();
        }
        else
        {
            Country = country;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Countries == null)
        {
            return NotFound();
        }
        var country = await _context.Countries.FindAsync(id);

        if (country != null)
        {
            Country = country;
            _context.Countries.Remove(Country);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
