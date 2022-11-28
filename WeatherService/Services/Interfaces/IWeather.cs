public interface IWeather
{
    double Lat { get; set; }
    double Long { get; set; }
    string City { get; set; }
    string Country { get; set; }
    string Icon { get; set; }
    double Temperature { get; set; }
    DateTime LastUpdated { get; set; }
    double Precip { get; set; }
    double FeelsLike { get; set; }
    double WindSpeed { get; set; }
}

