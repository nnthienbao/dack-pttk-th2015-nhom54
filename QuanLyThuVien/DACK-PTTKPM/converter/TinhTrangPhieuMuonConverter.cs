using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DTO;

namespace DACK_PTTKPM.CV
{
    public class TinhTrangPhieuMuonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tinhTrang = System.Convert.ToString(value);
            if(tinhTrang.Equals(TinhTrangPhieuMuon.DA_TRA))
            {
                return "Đã trả";
            }
            return "Chưa trả";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
