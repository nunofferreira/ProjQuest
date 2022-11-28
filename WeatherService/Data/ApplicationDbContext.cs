namespace WeatherService.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // public DbSet<Person> People { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #region model configurations

    // https://learn.microsoft.com/en-us/ef/core/modeling/

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(128);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateTime>().HavePrecision(0);
    }

    #endregion
}
