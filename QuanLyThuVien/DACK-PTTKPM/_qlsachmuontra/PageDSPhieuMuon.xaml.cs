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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS;
using DTO;
using DACK_PTTKPM.CV;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for PageDSPhieuMuon.xaml
    /// </summary>
    public partial class PageDSPhieuMuon : Page
    {
        public PageDSPhieuMuon()
        {
            InitializeComponent();
        }

        public void RefreshDanhSach()
        {
            this.dataGridPhieuMuon.ItemsSource = PhieuMuonSachBUS.Instance.LayDanhSach();
        }

        private void dataGridPhieuMuon_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }

        public PhieuMuonSach LayPhieuMuonSachDangChon()
        {
            return dataGridPhieuMuon.SelectedItem as PhieuMuonSach;
        }

        private void dataGridPhieuMuon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhieuMuonSach phieuMuonsachDangChon = LayPhieuMuonSachDangChon();
            if (phieuMuonsachDangChon == null) return;

            dataGridChiTietPhieuMuon.ItemsSource = phieuMuonsachDangChon.ChiTietPhieuMuons;

            // Hien thi thong tin phieu muon
            lb_TT_MaPhieuMuon.Content = phieuMuonsachDangChon.pid;
            lb_TT_MaDocgia.Content = phieuMuonsachDangChon.DocGia.mssv;
            lb_TT_HoTenDocgia.Content = phieuMuonsachDangChon.DocGia.HoTen;
            lb_TT_MaNguoiLap.Content = phieuMuonsachDangChon.NhanVien.pid;
            lb_TT_HoTenNguoiLap.Content = phieuMuonsachDangChon.NhanVien.Ten;
            lb_TT_TinhTrang.Content = (new TinhTrangPhieuMuonConverter()).Convert(phieuMuonsachDangChon.TinhTrang, null, null, null);
            DateConverter dateConverter = new DateConverter();
            lb_TT_NgayMuon.Content = dateConverter.Convert(phieuMuonsachDangChon.NgayMuon, null, "dd/MM/yyyy", null);
            lb_TT_HanTra.Content = dateConverter.Convert(phieuMuonsachDangChon.HanTra, null, "dd/MM/yyyy", null);
        }
    }
}
