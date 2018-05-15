using DTO;
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
using BUS;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PageDSNganhSach pageDSNganhSach = new PageDSNganhSach();
        private PageDSLoaiSach pageDSLoaiSach = new PageDSLoaiSach();
        public MainWindow()
        {
            InitializeComponent();
            this.MainArea.Content = pageDSNganhSach;
        }

        //
        //  Quan ly danh muc sach
        //

        //  Sach
        private void btnPageDSLoaiSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageDSLoaiSach;
        }

        private void btnThemLoaiSachClick(object sender, RoutedEventArgs e)
        {
            WindowThemLoaiSach wd = new WindowThemLoaiSach();
            if(wd.ShowDialog() == true)
            {
                pageDSLoaiSach.RefreshDanhSach();
            }
        }

        private void btnSuaLoaiSachClick(object sender, RoutedEventArgs e)
        {
            LoaiSach loaiSachDangChon = pageDSLoaiSach.GetLoaiSachDangChon();
            if (loaiSachDangChon == null) return;

            WindowSuaLoaiSach wd = new WindowSuaLoaiSach(loaiSachDangChon);
            if(wd.ShowDialog() == true)
            {
                pageDSLoaiSach.RefreshDanhSach();
            }
        }

        private void btnXoaLoaiSachClick(object sender, RoutedEventArgs e)
        {
            LoaiSach loaiSachDangChon = pageDSLoaiSach.GetLoaiSachDangChon();
            if (loaiSachDangChon == null) return;

            MessageBoxResult result = 
                MessageBox.Show("Xác nhận xóa loại sách ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(result == MessageBoxResult.OK)
            {
                LoaiSachBUS.Instance.XoaLoaiSach(loaiSachDangChon.pid);
                pageDSLoaiSach.RefreshDanhSach();
            }
        }

        //  Nganh sach
        private void btnPageDSNganhSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageDSNganhSach;
        }

        private void btnThemNganhSachClick(object sender, RoutedEventArgs e)
        {
            WindowThemNganhSach wd = new WindowThemNganhSach();
            if(wd.ShowDialog() == true)
            {
                pageDSNganhSach.refreshDanhSach();
            }
        }

        private void btnSuaNganhSachClick(object sender, RoutedEventArgs e)
        {
            NganhKhoa nganh = pageDSNganhSach.getNganhDangChon();
            if (nganh == null) return;

            WindowSuaNganhSach wd = new WindowSuaNganhSach(nganh);
            if(wd.ShowDialog() == true)
            {
                pageDSNganhSach.refreshDanhSach();
            }
        }

        private void btnXoaNganhSachClick(object sender, RoutedEventArgs e)
        {
            NganhKhoa nganh = pageDSNganhSach.getNganhDangChon();
            if (nganh == null) return;
            string pid = nganh.pid;

            MessageBoxResult result =
                MessageBox.Show("Xác nhận xóa ngành sách ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(result == MessageBoxResult.OK)
            {
                NganhKhoaBUS.Instance.XoaNganhKhoa(pid);
                pageDSNganhSach.refreshDanhSach();
            }
        }

        //  Nha xuat ban
        private void btnPageDSNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSNhaXuatBan();
        }

        private void btnThemNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            WindowThemNhaXuatBan wd = new WindowThemNhaXuatBan();
            wd.Show(); 
        }

        private void btnSuaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            WindowSuaNhaXuatBan wd = new WindowSuaNhaXuatBan();
            wd.Show();
        }

        private void btnXoaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa nha xuat ban sach");
        }

        //  Sach
        private void btnPageDSSachClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSSach();
        }

        private void btnThemSachClick(object sender, RoutedEventArgs e)
        {
            WindowThemSach wd = new WindowThemSach();
            wd.Show();
        }

        private void btnSuaSachClick(object sender, RoutedEventArgs e)
        {
            WindowSuaSach wd = new WindowSuaSach();
            wd.Show();
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

        private void btnThemDocGiaClick(object sender, RoutedEventArgs e)
        {
            WindowThemDocGia wd = new WindowThemDocGia();
            wd.Show();
        }

        private void btnSuaDocGiaClick(object sender, RoutedEventArgs e)
        {
            WindowSuaDocGia wd = new WindowSuaDocGia();
            wd.Show();
        }

        private void btnXoaDocGiaClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa doc gia click");
        }
        //
        //  Quan ly phieu muon tra
        //
        private void btnPageDSPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = new PageDSPhieuMuon();
        }

        private void btnThemPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            WindowThemPhieuMuon wd = new WindowThemPhieuMuon();
            wd.Show();
        }

        private void btnSuaPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            WindowSuaPhieuMuon wd = new WindowSuaPhieuMuon();
            wd.Show();
        }

        private void btnXoaPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xoa phieu muon click");
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
