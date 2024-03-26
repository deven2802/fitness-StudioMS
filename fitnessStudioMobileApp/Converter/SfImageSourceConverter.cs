using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using Microsoft.Maui.Controls;

namespace fitnessStudioMobileApp.Converter
{
    public class SfImageSourceConverter : IValueConverter
    {
        //
        // Parameters:
        //   value:
        //
        //   targetType:
        //
        //   parameter:
        //
        //   culture:
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            return ImageSource.FromResource(typeof(SfImageSourceConverter).GetTypeInfo().Assembly.GetName().Name + ".Resources.Images." + text, typeof(SfImageSourceConverter).GetTypeInfo().Assembly);
        }

        //
        // Parameters:
        //   value:
        //
        //   targetType:
        //
        //   parameter:
        //
        //   culture:
        //
        // Exceptions:
        //   T:System.NotImplementedException:
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
