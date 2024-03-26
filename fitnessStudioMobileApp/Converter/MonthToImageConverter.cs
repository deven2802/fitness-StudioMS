using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fitnessStudioMobileApp.Converter
{
    internal class MonthToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    var monthName = string.Format("{0:MMMM}", value).ToLower();
                    return ImageSource.FromResource(typeof(SfImageSourceConverter).GetTypeInfo().Assembly.GetName().Name + ".Resources.Images." + monthName + ".png", typeof(SfImageSourceConverter).GetTypeInfo().Assembly);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in converter: {ex.Message}");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

