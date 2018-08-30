using System;
using System.Globalization;
using Xamarin.Forms;

namespace AirportInfo.Converter
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ReverseBool(value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ReverseBool(value);

        private static bool ReverseBool(object value) => !(bool)value;
    }
}
