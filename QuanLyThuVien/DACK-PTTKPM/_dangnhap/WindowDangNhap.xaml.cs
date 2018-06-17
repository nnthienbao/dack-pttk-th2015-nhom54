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
using DTO;
using BUS;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowDangNhap.xaml
    /// </summary>
    public partial class WindowDangNhap : Window
    {
        public WindowDangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            lb_Error_DangNhap.Visibility = Visibility.Collapsed;

            string maNhanVien = tb_MaNhanvien.Text;
            string matKhau = tb_MatKhau.Password;
            NhanVien nhanVien = NhanVienBUS.Instance.Authenticate(maNhanVien, matKhau);
            if(nhanVien == null)
            {
                lb_Error_DangNhap.Visibility = Visibility.Visible;
            } else
            {
                MainWindow mainWindow = new MainWindow(nhanVien);
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
