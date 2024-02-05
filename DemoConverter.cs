using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DemoApp
{
    internal class DemoConverter : MarkupExtension, IValueConverter
    {
        private static DemoConverter? _instance;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new DemoConverter();
        }
    }
}
