using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfAzubi.Models;
        //https://stackoverflow.com/questions/345385/wpf-textblock-binding-with-liststring
namespace WpfAzubi.Converters
{
    /// <summary>Convertisseur pour concaténer des objets.</summary>
    [ValueConversion(typeof(IEnumerable<object>), typeof(object))]
    public class ConvListToString : IValueConverter
    {
        /// <summary>Convertisseur pour le Get.</summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var items = from p in ((List<Koennen>)value)
                        where p.IsSelected
                        select p.name;

            return String.Join(", ", items.ToArray());
            //return String.Join(", ", ((IEnumerable<object>)value).ToArray());
        }
        /// <summary>Convertisseur inverse, pour le Set (Binding).</summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
