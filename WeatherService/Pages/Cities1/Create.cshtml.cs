namespace WeatherService.Pages.cities1;

[Authorize]
public class CreateModel : PageModel
{
    private readonly WeatherService.Data.ApplicationDbContext _context;

    public CreateModel(WeatherService.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
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

        _context.Cities.Add(City);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
