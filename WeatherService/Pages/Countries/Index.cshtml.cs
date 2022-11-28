namespace WeatherService.Pages.Countries;

public class IndexModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public IndexModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Country> Country { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Countries != null)
        {
            Country = await _context.Countries.ToListAsync();
        }
    }
}