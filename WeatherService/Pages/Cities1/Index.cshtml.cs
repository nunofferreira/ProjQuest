namespace WeatherService.Pages.cities1;

[Authorize]
public class IndexModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public IndexModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<City> City { get; set; } = default!;

    public async Task OnGetAsync()
    {
        // obter o userId do utilizador "logado"
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (_context.Cities != null)
        {
            City = await _context.Cities
            .Include(c => c.Country).ToListAsync();
        }
    }
}
