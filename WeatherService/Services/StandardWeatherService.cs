public class StandardWeatherService : IWeatherService
{
    public async Task<IWeather> GetWeatherAsync(string city)
    {
        return new WeatherData()
        {
            City = city,
            Country = "Portugal",
            Icon = ":)",
            Lat = Random.Shared.NextDouble() * 100,
            Long = Random.Shared.NextDouble() * 100,
            Temperature = Random.Shared.Next(5, 45),
            LastUpdated = DateTime.Now,
        };
    }
}