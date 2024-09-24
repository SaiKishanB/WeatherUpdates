using System.Threading.Tasks;
using WeatherUpdates.Models;

namespace WeatherUpdates.Services
{
    public interface IWeatherService
    {
        Task<WeatherData?> GetWeatherAsync(double latitude, double longitude);
        double ConvertTemperature(double temperature, string fromUnit, string toUnit);
        Task<(double AverageTemperature, double HighestTemperature, double LowestTemperature)> GetTemperatureStatisticsAsync(double latitude, double longitude, int days);
    }
}
