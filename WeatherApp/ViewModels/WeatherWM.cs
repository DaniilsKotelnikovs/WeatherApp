using System.ComponentModel;

namespace WeatherApp.ViewModels
{
    public class WeatherWM : INotifyPropertyChanged
    {
        private string? query;

        public string? Query

        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
