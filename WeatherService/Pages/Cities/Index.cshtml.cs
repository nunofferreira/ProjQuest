namespace WeatherService.Pages.Cities;

public class IndexModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public IndexModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<City> Cities { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Cities != null)
        {
            Cities = await _context.Cities.Where(cidade => cidade.Temperature < 10).ToListAsync();
        }
    }
}
