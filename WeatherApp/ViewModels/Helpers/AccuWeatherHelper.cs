﻿using Newtonsoft.Json;
using System;
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
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "rO5aEChWqIXmwnfrGBCBHHxA2I2oKbSn";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                try
                {
                    cities = JsonConvert.DeserializeObject<List<City>>(json);
                }
                catch(Exception exception)
                {
                    return cities;
                }
            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            CurrentConditions currrentConditions = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                try
                {
                    currrentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
                }
                catch(Exception exception)
                {
                    return currrentConditions;
                }
            }

            return currrentConditions;
        }

    }
}
