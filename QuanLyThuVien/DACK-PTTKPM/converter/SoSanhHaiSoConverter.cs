using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DACK_PTTKPM.CV
{
    public class SoSanhHaiSoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int num1 = System.Convert.ToInt32(values[0]);
            int num2 = System.Convert.ToInt32(values[1]);

            if (num1 < num2) return -1;
            if (num1 > num2) return 1;
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
