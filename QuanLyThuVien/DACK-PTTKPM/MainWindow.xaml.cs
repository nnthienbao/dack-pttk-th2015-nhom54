using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MainArea.Content = new PageDSLoaiSach();
        }

        //
        // Quan ly danh muc sach
        //
        private void btnPageDSLoaiSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSLoaiSach();
        }

        private void btnThemLoaiSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Them loai sach");
        }

        private void btnSuaLoaiSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sua loai sach");
        }

        private void btnXoaLoaiSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa loai sach");
        }

        //
        private void btnPageDSNganhSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSNganhSach();
        }

        private void btnThemNganhSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Them Nganh sach");
        }

        private void btnSuaNganhSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sua Nganh sach");
        }

        private void btnXoaNganhSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa Nganh sach");
        }

        //
        private void btnPageDSNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSNhaXuatBan();
        }

        private void btnThemNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Them nha xuat ban sach");
        }

        private void btnSuaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sua nha xuat ban sach");
        }

        private void btnXoaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa nha xuat ban sach");
        }

        //
        private void btnPageDSSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSSach();
        }

        private void btnThemSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Them sach");
        }

        private void btnSuaSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sua thong tin sach");
        }

        private void btnXoaSachClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa thong tin sach");
        }

        //
        //  Quan ly doc gia 
        //
        private void btnPageDSDocGiaClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSDocGia();
        }

        //
        //  Quan ly phieu muon tra
        //
        private void btnPageDSPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSPhieuMuon();
        }

        private void btnPageDSPhieuTraClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSPhieuTra();
        }

        //
        //  Bao cao - thong ke 
        //
        private void btnPageDSViPhamClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSViPham();
        }

        private void btnPageDSSachItMuonClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSSachItMuon();
        }

        private void btnPageDSSachHongClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSSachHong();
        }
    }
}
