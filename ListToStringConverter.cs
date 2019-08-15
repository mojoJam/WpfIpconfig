using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Data;
using WpfAzubi.Models;
 

namespace WpfAzubi.Converters
{
    [ValueConversion(typeof(List<string>), typeof(string))]
    public class ListToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(List<Koennen>))
                throw new InvalidOperationException("The target must be a String");
             var items = from p in ((List<Koennen>)value)
                 where p. IsSelected
                select p.name;
          
             return String.Join(", ", items.ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
