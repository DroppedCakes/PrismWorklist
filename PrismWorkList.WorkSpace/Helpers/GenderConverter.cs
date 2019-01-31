using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PrismWorkList.WorkSpace.Helpers
{
    public class GenderConverter : IValueConverter
    {
       private IEnumerable<GenderType> _genders { get; }
        
        public GenderConverter(IEnumerable<GenderType>genders)
        {
            _genders = genders;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ////    _genders.Select(x=>x.Code)
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
