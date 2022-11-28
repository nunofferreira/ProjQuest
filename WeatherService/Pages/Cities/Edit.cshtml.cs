namespace WeatherService.Pages.Cities;

public class EditModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public EditModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public City City { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Cities == null)
        {
            return NotFound();
        }

        var city = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }
        City = city;
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

        _context.Attach(City).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CityExists(City.Id))
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

    private bool CityExists(int id)
    {
        return _context.Cities.Any(e => e.Id == id);
    }
}
