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
    /// Interaction logic for WindowThemNhaXuatBan.xaml
    /// </summary>
    public partial class WindowThemNhaXuatBan : Window
    {
        public WindowThemNhaXuatBan()
        {
            InitializeComponent();
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenNhaXuatBan.Content = "";
            string tenNXB = tb_TenNhaXuatBan.Text;
            
            if(string.IsNullOrEmpty(tenNXB))
            {
                lb_Loi_TenNhaXuatBan.Content = "Tên nhà xuất bản không được để trống";
            } else
            {
                try
                {
                    NhaXuatBanBUS.Instance.ThemNhaXuatBan(tenNXB);
                    this.DialogResult = true;
                } catch(Exception ex)
                {
                    lb_Loi_TenNhaXuatBan.Content = "Tên nhà xuất bản phải từ 1-50 ký tự";
                }
            }
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
