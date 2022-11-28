namespace WeatherService.Pages.Cities;

public class CreateModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(WeatherService.Data.ApplicationDbContext context,
        ILogger<CreateModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public City City { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        City.LastUpdated = DateTime.Now;
        City.CountryId = 1;
        _context.Cities.Add(City);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
