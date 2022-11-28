public class Location
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }

    [JsonPropertyName("region")] // Data anotations
    public string Region { get; set; }

    [JsonPropertyName("timezone_id")]
    public string TimeZoneId { get; set; }
}
