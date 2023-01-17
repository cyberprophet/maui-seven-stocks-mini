using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

using System;
using System.Globalization;

namespace DevExpress.Maui.Demo.Stocks
{
    public class DoubleToImageSourceConverter : IValueConverter, IMarkupExtension<DoubleToImageSourceConverter>
    {
        public ImageSource ZeroValue { get; set; } = string.Empty;
        public ImageSource PositiveValue { get; set; } = string.Empty;
        public ImageSource NegativeValue { get; set; } = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double doubleValue || targetType != typeof(ImageSource))
                return null;

            return doubleValue switch
            {
                > 0 => PositiveValue,
                < 0 => NegativeValue,
                _ => ZeroValue
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        DoubleToImageSourceConverter IMarkupExtension<DoubleToImageSourceConverter>.ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
    public class DoubleToColorConverter : IValueConverter, IMarkupExtension<DoubleToColorConverter>
    {
        public string ZeroValue { get; set; } = string.Empty;
        public string PositiveValue { get; set; } = string.Empty;
        public string NegativeValue { get; set; } = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not double doubleValue || targetType != typeof(Color) ? null :
                
                (object)(doubleValue switch
                {
                    > 0 => (Color)Application.Current.Resources[PositiveValue],
                    < 0 => (Color)Application.Current.Resources[NegativeValue],
                    _ => (Color)Application.Current.Resources[ZeroValue],
                });
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        public DoubleToColorConverter ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}