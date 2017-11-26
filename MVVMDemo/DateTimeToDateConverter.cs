using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMDemo
{
    [ValueConversion(typeof(object), typeof(string))]
    public class DatetimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("yyyy/MM/dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
    }
}