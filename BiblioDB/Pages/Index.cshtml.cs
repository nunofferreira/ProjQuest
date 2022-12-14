namespace BiblioDB.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _ctx;

    public IndexModel(ILogger<IndexModel> logger,
        ApplicationDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    public List<Book> BookList { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_ctx.Books != null)
            BookList = await _ctx.Books.ToListAsync();
    }       
}