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
    /// Interaction logic for WindowSuaNhaXuatBan.xaml
    /// </summary>
    public partial class WindowSuaNhaXuatBan : Window
    {
        private NhaXuatBan nhaXuatBan;

        public WindowSuaNhaXuatBan(NhaXuatBan nhaXuatBan)
        {
            this.nhaXuatBan = nhaXuatBan;
            InitializeComponent();
        }

        private string tenNXBCu = "";
        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenNhaXuatBan.Content = "";
            string tenNXBMoi = tb_TenNhaXuatBan.Text;

            if(string.IsNullOrEmpty(tenNXBMoi))
            {
                lb_Loi_TenNhaXuatBan.Content = "Tên nhà xuất bản không được để trống";
            } else
            {
                tenNXBCu = nhaXuatBan.Ten;
                nhaXuatBan.Ten = tenNXBMoi;
                try
                {
                    NhaXuatBanBUS.Instance.SuaNhaXuatBan(nhaXuatBan);
                    this.DialogResult = true;
                } catch (Exception ex)
                {
                    nhaXuatBan.Ten = tenNXBCu;
                    lb_Loi_TenNhaXuatBan.Content = "Tên nhà xuất bản phải từ 1-50 ký tự";
                }
            }
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.tb_MaNhaXuatBan.Text = nhaXuatBan.pid;
            this.tb_TenNhaXuatBan.Text = nhaXuatBan.Ten;
        }
    }
}
