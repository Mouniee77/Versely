using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class StringNullOrEmptyToVisibilityConverter : IValueConverter
    {
        public bool CollapseWhenInvisible { get; set; } = true;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            var isEmpty = string.IsNullOrWhiteSpace(s);
            return isEmpty ? Visibility.Visible : (CollapseWhenInvisible ? Visibility.Collapsed : Visibility.Hidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}