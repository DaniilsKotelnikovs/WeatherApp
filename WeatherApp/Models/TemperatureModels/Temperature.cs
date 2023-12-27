using WeatherApp.Models.TemperatureModels.Types;

namespace WeatherApp.Models
{
    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
}
