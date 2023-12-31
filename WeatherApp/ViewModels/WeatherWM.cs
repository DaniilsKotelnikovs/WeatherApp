﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Models;
using WeatherApp.Models.TemperatureModels.Types;
using WeatherApp.ViewModels.Commands;
using WeatherApp.ViewModels.Helpers;

namespace WeatherApp.ViewModels
{
    public class WeatherWM : INotifyPropertyChanged
    {
        private string query = string.Empty;

        public string Query

        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions? currentConditions;

        public CurrentConditions? CurrentConditions
        {
            get { return currentConditions; }
            set 
            {
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            { 
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentConditions();
            }
        }

        public SearchCommand SearchCommand { get; set; }

        public WeatherWM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {

                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "21"
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
        }

        private async void GetCurrentConditions()
        {
            Query = string.Empty;
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();

            foreach(City city in cities)
            {
                Cities.Add(city);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
