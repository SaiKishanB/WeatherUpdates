using System.Collections.Generic;

namespace WeatherUpdates.Models
{
    public class WeatherApiResponse
    {
        public List<WeatherApiData> Data { get; set; } = new List<WeatherApiData>();
    }

    public class WeatherApiData
    {
        public double Temp { get; set; }
        public int Rh { get; set; }
        public double Wind_spd { get; set; }
        public WeatherDescription Weather { get; set; } = new WeatherDescription();
    }

    public class WeatherDescription
    {
        public string Description { get; set; } = string.Empty;
    }
}
