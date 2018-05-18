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
    /// Interaction logic for WindowThemLoaiSach.xaml
    /// </summary>
    public partial class WindowThemLoaiSach : Window
    {
        public WindowThemLoaiSach()
        {
            InitializeComponent();
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenLoaiSach.Content = "";

            string tenLoai = tb_TenLoaiSach.Text;

            if(string.IsNullOrEmpty(tenLoai))
            {
                lb_Loi_TenLoaiSach.Content = "Tên loại sách không được để trống";
            } else
            {
                LoaiSachBUS.Instance.ThemLoaiSach(tenLoai);
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
