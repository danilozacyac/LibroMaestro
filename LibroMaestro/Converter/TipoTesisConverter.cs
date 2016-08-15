using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace LibroMaestro.Converter
{
    public class TipoTesisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int tipoTesis = value as int? ?? 0;

            switch (tipoTesis)
            {
                case 1: return new SolidColorBrush(Colors.LightBlue);
                case 0: return new SolidColorBrush(Colors.White);  // 

                default: return new SolidColorBrush(Colors.White);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
