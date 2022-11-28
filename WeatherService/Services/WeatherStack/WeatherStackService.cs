public class WeatherStackService : IWeatherService
{
    private static string
        url = "http://api.weatherstack.com/current?access_key=e26a762017e86b80991ddef07887c650&query=";

    public async Task<IWeather> GetWeatherAsync(string city)
    {// Mudar o método (que está a chamar o método Async) para async Task<>)
        var endpoint = url + city;

        var client = new RestClient(endpoint);
        var request = new RestRequest("", Method.Get);
        RestResponse<Root> response = await client.ExecuteAsync<Root>(request); 
        // Palavra reservada await, para usar o método Async

        var apiData = response.Data;

        //var json = response.Content;

        //var jsonToFile = System.Text.Json.JsonSerializer.Serialize(json);
        //File.WriteAllText("data.json", jsonToFile);

        // var jsonFromFile = File.ReadAllText("data.json");
        //var apiData = System.Text.Json.JsonSerializer.Deserialize<Root>(json);


        //var enCulture = CultureInfo.GetCultureInfo("en");
        return new WeatherData()
        {
            City = city,
            Country = apiData.Location.Country,
            Temperature = apiData.Current.Temperature,
            Lat = double.Parse(apiData.Location.Lat/*, enCulture*/),
            Long = double.Parse(apiData.Location.Lon/*, enCulture*/),
            Icon = apiData.Current.Icons.FirstOrDefault(),
            LastUpdated = DateTime.UtcNow,
            Precip = apiData.Current.Precip,
            FeelsLike = apiData.Current.FeelsLike,
            WindSpeed = apiData.Current.WindSpeed,
        };
    }
}
