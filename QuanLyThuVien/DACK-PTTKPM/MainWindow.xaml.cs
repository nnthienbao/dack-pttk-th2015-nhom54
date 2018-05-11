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

        private void btnPageDSLoaiSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSLoaiSach();
        }

        private void btnPageDSNganhSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSNganhSach();
        }

        private void btnPageDSNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSNhaXuatBan();
        }

        private void btnPageDSSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSSach();
        }

        private void btnPageDSDocGiaClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSDocGia();
        }

        private void btnPageDSPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSPhieuMuon();
        }

        private void btnPageDSPhieuTraClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSPhieuTra();
        }

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
