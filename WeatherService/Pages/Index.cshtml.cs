namespace WeatherService.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _ctx;
    private readonly IWeatherService _service;
    private readonly CountryRepository _countryRepository;
    private readonly CityRepository _cityRepository;

    public int NumDays { get; set; } = 100;
    public IWeather MyWeatherData { get; set; }

    public IndexModel(ILogger<IndexModel> logger,
       ApplicationDbContext ctx, //dependency injection context
       IWeatherService weatherService, //dependency injection IWeatherService
       CountryRepository countryRepository,
       CityRepository cityRepository)
    {
        _logger = logger;
        _ctx = ctx;
        _service = weatherService;
        _countryRepository = countryRepository;
        _cityRepository = cityRepository;
        //_service = new StandardWeatherService();
    }

    // MVC
    // Model View Controller
    // Método que é chamado automaticamente quando a página é chamada
    public async Task OnGetAsync(string? city)
    {
        _logger.LogWarning($"Executando Index com cidade: {city}");
        _logger.LogCritical($"Executando Index com cidade: {city}");
        _logger.LogInformation($"Executando Index com cidade: {city}");

        // servidor => cliente
        city = city ?? "Liverpool";
        //country = country ?? Data.Entities.Country;
        // ?? -> null coalescent operator
        // Se a cidade for null, vai atribuir Liverpool

        MyWeatherData = await _service.GetWeatherAsync(city);

        // Ter uma instância de DbContext
        // Adicionar a nova entidade à coleção correspondente (no  DbContext)
        // Gravar alterações

        var country = await _countryRepository.GetCountryByNameAsync(MyWeatherData.Country) // Se este for nulo
            ?? await _countryRepository.CreateAsync(MyWeatherData.Country);                 // Vai atribuir a este

        //// Se o country não existir
        //if (country == null)
        //{
        //    country = await _countryRepository.CreateAsync(MyWeatherData.Country)

        //}

        //var cityModel = new City() // → novo objeto criado
        //{
        //    // Id → como é auto-incrementado não se coloca aqui
        //    Name = MyWeatherData.City,
        //    Temperature = MyWeatherData.Temperature,
        //    LastUpdated = MyWeatherData.LastUpdated,
        //    CountryId = country.Id,
        //};

        //await _cityRepository.CreateAsync(cityModel);

        await _cityRepository.CreateAsync(MyWeatherData.City, MyWeatherData.Temperature,
            MyWeatherData.LastUpdated, country.Id);

        //_ctx.Cities.Add(cityModel); // → objeto adicionado à lista de cities
        //await _ctx.SaveChangesAsync(); // → objeto gravado
    }

    public void OnPost()
    {
        // cliente => servidor
    }
}