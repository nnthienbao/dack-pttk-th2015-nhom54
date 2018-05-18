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

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowThemNganhSach.xaml
    /// </summary>
    public partial class WindowThemNganhSach : Window
    {
        public WindowThemNganhSach()
        {
            InitializeComponent();
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenNganh.Content = "";
            String tenNganh = tb_TenNganhSach.Text;
            if(String.IsNullOrEmpty(tenNganh))
            {
                lb_Loi_TenNganh.Content = "Tên ngành không được để trống";
            } else
            {
                NganhKhoaBUS.Instance.ThemNganhKhoa(tenNganh);
                this.DialogResult = true;
            }
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
