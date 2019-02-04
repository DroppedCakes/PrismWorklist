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
        private static IEnumerable<GenderType> _genders { get; set; }

        public GenderConverter()
        {
        }

        public static void SetReSource(IEnumerable<GenderType> genderTypes)
            => _genders = genderTypes;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _genders.Where(x => x.Code == value as string).Select(x => x.Name).FirstOrDefault().ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
