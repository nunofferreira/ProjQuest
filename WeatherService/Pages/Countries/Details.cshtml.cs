namespace WeatherService.Pages.Countries;

public class DetailsModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public DetailsModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

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
}
