var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => // DefaultConnection is located in appsettings.json
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

#region Our Configurations

// Quando encontrar um tipo IWeather service no construtor,
// irá ser criado um objeto do tipo que está identificado depois da vírgula
builder.Services.AddScoped<IWeatherService, WeatherStackService>();
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<CityRepository>();

// AddTransient -> Cria um novo objeto sempre que seja solicitado  (refresh na página vai criar um novo obj)
// AddScoped    -> Cria um único objeto por request
// AddSingleton -> Cria um único objeto enquanto a app estiver a correr

#endregion Our Configurations

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();