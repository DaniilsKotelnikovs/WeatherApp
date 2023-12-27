using WeatherApp.Model.TemperatureModels.Types;

namespace WeatherApp.Model
{
    public class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
}
