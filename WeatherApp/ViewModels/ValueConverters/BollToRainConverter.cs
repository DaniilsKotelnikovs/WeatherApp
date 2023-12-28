using System;
using System.Globalization;
using System.Windows.Data;

namespace WeatherApp.ViewModels.ValueConverters
{
    public class BollToRainConverter : IValueConverter
    {
        private const string RainingString = "Currently raining";
        private const string NotRainingString = "Currently not raining";


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining = (bool)value;

            if(isRaining)
            {
                return RainingString;
            }

            return NotRainingString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isRaining = (string)value;

            if (isRaining == RainingString)
            {
                return true;
            }

            return false;
        }
    }
}
