using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels.Helpers
{
    public static class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}n&q={1}";
        public const string CURRENT_CONTIDIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "rO5aEChWqIXmwnfrGBCBHHxA2I2oKbSn";

        public static async Task<List<City>> GetCities(string querry)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, querry);

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response is null) return cities;

                string json = await response.Content.ReadAsStringAsync();

                if (json is null) return cities;

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONTIDIONS_ENDPOINT, API_KEY, cityKey);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response is null) return currentConditions;

                string json = await response.Content.ReadAsStringAsync();

                if (json is null) return currentConditions;

                currentConditions = JsonConvert.DeserializeObject<List<CurrentConditions>>(json).FirstOrDefault();
            }

            return currentConditions;
        }

    }
}
