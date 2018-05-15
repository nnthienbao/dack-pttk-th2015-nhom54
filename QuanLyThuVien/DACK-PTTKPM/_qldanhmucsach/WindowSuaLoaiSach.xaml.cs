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
    /// Interaction logic for WindowSuaLoaiSach.xaml
    /// </summary>
    public partial class WindowSuaLoaiSach : Window
    {
        private LoaiSach loaiSach = null;
        public WindowSuaLoaiSach(LoaiSach loaiSach)
        {
            this.loaiSach = loaiSach;
            InitializeComponent();
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenLoaiSach.Content = "";
            string tenLoaiMoi = tb_TenLoaiSach.Text;
            
            if(string.IsNullOrEmpty(tenLoaiMoi))
            {
                lb_Loi_TenLoaiSach.Content = "Tên loại sách không được để trống";
            } else
            {
                loaiSach.Ten = tenLoaiMoi;
                LoaiSachBUS.Instance.SuaLoaiSach(loaiSach);
                this.DialogResult = true;
            }
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.tb_MaLoaiSach.Text = loaiSach.pid;
            this.tb_TenLoaiSach.Text = loaiSach.Ten;
        }
    }
}
