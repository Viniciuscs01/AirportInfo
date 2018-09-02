using System;
using System.Globalization;
using Xamarin.Forms;

namespace AirportInfo.Converter
{
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString()?.ToUpperInvariant();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString()?.ToLowerInvariant();
    }
}
