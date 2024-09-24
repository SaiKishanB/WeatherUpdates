namespace WeatherUpdates.Models
{
    public class WeatherData
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string WeatherDescription { get; set; } = string.Empty;
    }
}
