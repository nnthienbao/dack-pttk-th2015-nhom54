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
        private NhanVien nhanVienSuDung = null;

        private PageDSNganhSach pageDSNganhSach = new PageDSNganhSach();
        private PageDSLoaiSach pageDSLoaiSach = new PageDSLoaiSach();
        private PageDSNhaXuatBan pageDSNhaXuatBan = new PageDSNhaXuatBan();
        private PageDSSach pageDSSach = new PageDSSach();
        private PageDSPhieuMuon pageDSPhieuMuon = new PageDSPhieuMuon();
        private PageDSDocGia pageDSDocGia = new PageDSDocGia();
        public MainWindow(NhanVien nhanVienSuDung)
        {
            InitializeComponent();
            this.nhanVienSuDung = nhanVienSuDung;
            this.MainArea.Content = pageDSSach;
        }

        public NhanVien NhanVienSuDung
        {
            get
            {
                return nhanVienSuDung;
            }
        }
        //
        //  Quan ly danh muc sach
        //

        //  Sach
        private void btnPageDSLoaiSachClick(object sender, RoutedEventArgs e)
        {
            if (this.MainArea.Content != pageDSLoaiSach)
            {
                this.MainArea.Content = pageDSLoaiSach;
            } else
            {
                pageDSLoaiSach.RefreshDanhSach();
            }
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
            if (this.MainArea.Content != pageDSNganhSach)
            {
                this.MainArea.Content = pageDSNganhSach;
            } else
            {
                pageDSNganhSach.refreshDanhSach();
            }
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
            if (this.MainArea.Content != pageDSNhaXuatBan)
            {
                this.MainArea.Content = pageDSNhaXuatBan;
            } else
            {
                pageDSNhaXuatBan.RefreshDanhSach();
            }
        }

        private void btnThemNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            WindowThemNhaXuatBan wd = new WindowThemNhaXuatBan();
            if(wd.ShowDialog() == true)
            {
                pageDSNhaXuatBan.RefreshDanhSach();
            }
        }

        private void btnSuaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            NhaXuatBan nxbDangChon = pageDSNhaXuatBan.GetNhaXuatBanDangChon();
            if (nxbDangChon == null) return;

            WindowSuaNhaXuatBan wd = new WindowSuaNhaXuatBan(nxbDangChon);
            if(wd.ShowDialog() == true)
            {
                pageDSNhaXuatBan.RefreshDanhSach();
            }
        }

        private void btnXoaNhaXuatBanClick(object sender, RoutedEventArgs e)
        {
            NhaXuatBan nxbDangChon = pageDSNhaXuatBan.GetNhaXuatBanDangChon();
            if (nxbDangChon == null) return;

            MessageBoxResult result =
                MessageBox.Show("Xác nhận xóa nhà xuất bản ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                NhaXuatBanBUS.Instance.XoaNhaXuatBan(nxbDangChon.pid);
                pageDSNhaXuatBan.RefreshDanhSach();
            }
        }

        //  Sach
        private void btnPageDSSachClick(object sender, RoutedEventArgs e)
        {
            if (this.MainArea.Content != pageDSSach)
            {
                this.MainArea.Content = pageDSSach;
            } else
            {
                pageDSSach.RefreshDanhSach();
            }
        }

        private void btnThemSachClick(object sender, RoutedEventArgs e)
        {
            WindowThemSach wd = new WindowThemSach();
            if(wd.ShowDialog() == true)
            {
                pageDSSach.RefreshDanhSach();
            }
        }

        private void btnSuaSachClick(object sender, RoutedEventArgs e)
        {
            Sach sachDangChon = pageDSSach.LaySachDangChon();
            if (sachDangChon == null) return;

            WindowSuaSach wd = new WindowSuaSach(sachDangChon);
            if(wd.ShowDialog() == true)
            {
                pageDSSach.RefreshDanhSach();
            }
        }

        private void btnXoaSachClick(object sender, RoutedEventArgs e)
        {
            Sach sachDangChon = pageDSSach.LaySachDangChon();
            if (sachDangChon == null) return;

            MessageBoxResult result =
                MessageBox.Show("Xác nhận xóa sách ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(result == MessageBoxResult.OK)
            {
                SachBUS.Instance.XoaSach(sachDangChon.id);
                pageDSSach.RefreshDanhSach();
            }
        }

        //
        //  Quan ly doc gia 
        //
        private void btnPageDSDocGiaClick(object sender, RoutedEventArgs e)
        {
            if (this.MainArea.Content != pageDSDocGia)
            {
                this.MainArea.Content = pageDSDocGia;
            }
            else
            {
                pageDSDocGia.RefreshDanhSach();
            }
            
        }

        private void btnThemDocGiaClick(object sender, RoutedEventArgs e)
        {
            WindowThemDocGia wd = new WindowThemDocGia();
            if (wd.ShowDialog() == true)
            {
                pageDSDocGia.RefreshDanhSach();
            }
        }

        private void btnSuaDocGiaClick(object sender, RoutedEventArgs e)
        {
            DocGia docGia = pageDSDocGia.LayDocGiaDangChon();
            if (docGia == null)
                return;

            WindowSuaDocGia wd = new WindowSuaDocGia(docGia);
            if (wd.ShowDialog() == true)
            {
                pageDSDocGia.RefreshDanhSach();
            }
        }

        private void btnXoaDocGiaClick(object sender, RoutedEventArgs e)
        {
            DocGia docGia = pageDSDocGia.LayDocGiaDangChon();
            if (docGia == null) return;

            MessageBoxResult result =
                MessageBox.Show("Xác nhận xóa Độc giả ?", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                DocGiaBUS.Instance.XoaDocGia(docGia.mssv);
                pageDSDocGia.RefreshDanhSach();
            }
        }
        //
        //  Quan ly phieu muon tra
        //
        private void btnPageDSPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageDSPhieuMuon;
        }

        private void btnThemPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            WindowThemPhieuMuon wd = new WindowThemPhieuMuon(this.nhanVienSuDung);
            if(wd.ShowDialog() == true)
            {
                pageDSPhieuMuon.RefreshDanhSach();
            }
        }

        private void btnSuaPhieuMuonClick(object sender, RoutedEventArgs e)
        {
            PhieuMuonSach pmsDangChon = pageDSPhieuMuon.LayPhieuMuonSachDangChon();
            if (pmsDangChon == null) return;

            WindowSuaPhieuMuon wd = new WindowSuaPhieuMuon(pmsDangChon);
            if(wd.ShowDialog() == true)
            {
                pageDSPhieuMuon.RefreshDanhSach();
            }
        }

        private void btnXoaPhieuMuon_Click(object sender, RoutedEventArgs e)
        {
            PhieuMuonSach pmsDangChon = pageDSPhieuMuon.LayPhieuMuonSachDangChon();
            if (pmsDangChon == null) return;
            MessageBoxResult msgResult = MessageBox.Show("Xác nhận xóa phiếu mượn", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(msgResult == MessageBoxResult.OK)
            {
                if (PhieuMuonSachBUS.Instance.XoaPhieuMuon(pmsDangChon.id))
                {
                    pageDSPhieuMuon.RefreshDanhSach();
                } else
                {
                    MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {

        }

        Page pageBaoCaoSachMuon = new BaoCaoSachMuon();
        Page pageBaoCaoSachConLai = new BaoCaoSachConLai();
        Page pageBaoCaoDocGiaDangKy = new BaoCaoDocGiaDangKy();
        Page pageDocGiaViPham = new BaoCaoDocGiaViPham();
        private void btnThongKeSLSachMuong_Click(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageBaoCaoSachMuon;
        }

        private void btnThongKeSachConLai_Click(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageBaoCaoSachConLai;
        }

        private void btnBaoCaoDocGiaDangKy_Click(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageBaoCaoDocGiaDangKy;
        }

        private void btnBaoCaoDocGiaViPham_Click(object sender, RoutedEventArgs e)
        {
            this.MainArea.Content = pageDocGiaViPham;
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.MainArea == null) return;
            RibbonTab tab = e.AddedItems[0] as RibbonTab;
            if (tab == null) return;
            switch(tab.Name)
            {
                case "QLDanhMucSach":
                    this.MainArea.Content = pageDSSach;
                    break;
                case "QLDocGia":
                    this.MainArea.Content = pageDSDocGia;
                    break;
                case "QLDanhPhieuMuonSach":
                    this.MainArea.Content = pageDSPhieuMuon;
                    break;
                case "BaoCaoThongKe":
                    this.MainArea.Content = pageBaoCaoSachMuon;
                    break;
            }
        }
    }
}
