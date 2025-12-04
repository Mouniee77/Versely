using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class StringNotEmptyToVisibilityConverter : IValueConverter
    {
        public bool CollapseWhenInvisible { get; set; } = true;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;

            return string.IsNullOrWhiteSpace(s) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}