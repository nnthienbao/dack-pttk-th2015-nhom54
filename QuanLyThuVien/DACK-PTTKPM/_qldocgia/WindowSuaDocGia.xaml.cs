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
    /// Interaction logic for WindowSuaDocGia.xaml
    /// </summary>
    public partial class WindowSuaDocGia : Window
    {
        DocGia docGia = null;

        public WindowSuaDocGia()
        {
            InitializeComponent();
        }

        public WindowSuaDocGia(DocGia docGia)
        {
            this.docGia = docGia;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb_MaSoDocGia.Text = docGia.mssv;
            tb_HoTenDocGia.Text = docGia.HoTen;

            if (docGia.GioiTinh == true)
            {
                rd_GioiTinhNam.IsChecked = true;
            } else
            {
                rd_GioiTinhNu.IsChecked = true;
            }

            dpicker_NgaySinh.SelectedDate = docGia.NgaySinh;
            dpicker_NgayMoThe.SelectedDate = docGia.NgayMoThe;
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
                BUS.DocGiaBUS.Instance.SuaDocGia(docGia);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra !", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
