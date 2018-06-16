using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BUS;

namespace DACK_PTTKPM.CV
{
    public class KTDuSoLuongSachKhiSua : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int maPhieuMuon = System.Convert.ToInt32(values[0]);
            int maSach = System.Convert.ToInt32(values[1]);
            int soLuongNhap = System.Convert.ToInt32(values[2]);

            if (maPhieuMuon == 0 && maSach == 0 && soLuongNhap == 0) return true;

            try
            {
                return ChiTietPhieuMuonBUS.Instance.KiemTraDuSoLuongMuon(maSach, maPhieuMuon, soLuongNhap);
            } catch
            {
                return true;
            }
           
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
