namespace BiblioDB.Data.Repositories;

public class BookRepository
{
    private readonly ApplicationDbContext _ctx;

    public BookRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Book>> FindByFilterAsync(BookFilter filter = null)
    {
        var books = _ctx.Books.AsQueryable();

        if (filter == null)
            return await books.ToListAsync();

        if (filter.Title != null)
            books = books.Where(b => b.Title.Contains(filter.Title));

        if (filter.PublishYear != null)
            books = books.Where(b => b.PublishYear == filter.PublishYear);

        if (filter.UserId != null)
            books = books.Where(b => b.UserId == filter.UserId);

        return await books.ToListAsync();

        //var books = await bookRepo.FindByFiltersAsync(new BookFilter() { UserId = "xxxxx" });
    }
}
