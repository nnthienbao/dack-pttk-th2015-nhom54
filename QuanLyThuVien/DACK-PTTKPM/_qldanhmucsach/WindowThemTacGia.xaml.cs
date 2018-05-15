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
    /// Interaction logic for WindowThemTacGia.xaml
    /// </summary>
    public partial class WindowThemTacGia : Window
    {
        public WindowThemTacGia()
        {
            InitializeComponent();
        }

        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenTacGia.Content = "";
            string tenTacGia = tb_TenTacGia.Text;

            if(string.IsNullOrEmpty(tenTacGia))
            {
                lb_Loi_TenTacGia.Content = "Tên tác giả không được để trống";
            } else
            {
                TacGiaBUS.Instance.ThemTacGia(tenTacGia);
                this.DialogResult = true;
            }
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
