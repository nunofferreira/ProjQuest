namespace WeatherService.Pages.cities1;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public DetailsModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

  public City City { get; set; }

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
        else 
        {
            City = city;
        }
        return Page();
    }
}
