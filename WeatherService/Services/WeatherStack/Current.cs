public class Current
{
    public double Temperature { get; set; }

    [JsonPropertyName("weather_icons")]
    public string[] Icons { get; set; }
    public double Precip { get; set; }
    public double FeelsLike { get; set; }
    public double WindSpeed { get; set; }
}