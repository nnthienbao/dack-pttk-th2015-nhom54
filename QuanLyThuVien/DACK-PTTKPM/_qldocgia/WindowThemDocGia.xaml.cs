using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BUS;
using DTO;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowThemDocGia.xaml
    /// </summary>
    public partial class WindowThemDocGia : Window
    {
        public WindowThemDocGia()
        {
            InitializeComponent();
        }

        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            panel_Error_MaSoDocGia.Visibility = Visibility.Collapsed;
            panel_Error_HoTenDocGia.Visibility = Visibility.Collapsed;

            String maSoDocGia = tb_MaSoDocGia.Text;
            String hoTenDocGia = tb_HoTenDocGia.Text;
            bool gioiTinhDocGia = true;
            DateTime ngaySinh = (DateTime)dpicker_NgaySinh.SelectedDate;
            DateTime ngayMoThe = (DateTime)dpicker_NgayMoThe.SelectedDate;

            bool error = false;

            if (maSoDocGia.Length != 7)
            {
                lb_Error_MaSoDocGia.Content = "Mã số độc giả phải có 7 ký tự";
                panel_Error_MaSoDocGia.Visibility = Visibility.Visible;
                error = true;
            }
            else
            {
                foreach (char c in maSoDocGia)
                {
                    if (c < '0' || c > '9')
                    {
                        lb_Error_MaSoDocGia.Content = "Mã số độc giả chỉ chứa ký tự số";
                        panel_Error_MaSoDocGia.Visibility = Visibility.Visible;
                        error = true;
                    } 
                }
            }

            if (String.IsNullOrEmpty(hoTenDocGia))
            {
                lb_Error_HoTenDocGia.Content = "Họ tên độc giả không được để trống";
                panel_Error_HoTenDocGia.Visibility = Visibility.Visible;
                error = true;
            }

            if (rd_GioiTinhNam.IsChecked == false)
            {
                gioiTinhDocGia = false;
            }

            DocGia docGia = new DocGia
            {
                mssv = maSoDocGia,
                HoTen = hoTenDocGia,
                GioiTinh = gioiTinhDocGia,
                NgaySinh = ngaySinh,
                NgayMoThe = ngayMoThe,
            };

            try
            {
                BUS.DocGiaBUS.Instance.ThemDocGia(docGia);
                this.DialogResult = true;
            } catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra !", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
