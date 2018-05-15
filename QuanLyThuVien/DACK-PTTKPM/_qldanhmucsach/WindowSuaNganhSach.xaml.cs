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
    /// Interaction logic for WindowSuaNganhSach.xaml
    /// </summary>
    public partial class WindowSuaNganhSach : Window
    {
        private NganhKhoa nganhKhoa = null;
        public WindowSuaNganhSach(NganhKhoa nganhKhoa)
        {
            InitializeComponent();
            this.nganhKhoa = nganhKhoa;

            tb_MaNganhSach.Text = nganhKhoa.pid;
            tb_TenNganhSach.Text = nganhKhoa.Ten;
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenNganh.Content = "";
            string tenMoi = tb_TenNganhSach.Text;

            if(string.IsNullOrEmpty(tenMoi))
            {
                lb_Loi_TenNganh.Content = "Tên ngành không được để trống";
            } else
            {
                // Gọi bus sửa ngành sách
                nganhKhoa.Ten = tenMoi;
                NganhKhoaBUS.Instance.SuaNganhKhoa(nganhKhoa);
                this.DialogResult = true;
            }
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
