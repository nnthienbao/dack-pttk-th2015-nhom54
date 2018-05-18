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
using DTO;
using BUS;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for Sach.xaml
    /// </summary>
    public partial class PageDSSach : Page
    {
        public PageDSSach()
        {
            InitializeComponent();
        }

        public void RefreshDanhSach()
        {
            dataGridSach.ItemsSource = SachBUS.Instance.LayDanhSach();
        }

        private void dataGridSach_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }

        public Sach LaySachDangChon()
        {
            return dataGridSach.SelectedItem as Sach;
        }

        private void btn_TimKiemSach_Click(object sender, RoutedEventArgs e)
        {
            if(rd_TimKiemSachTheoMa.IsChecked == true)
            {
                TimKiemSachTheoMa();

            } else if(rd_TimKiemSachTheoTen.IsChecked == true)
            {
                TimKiemSachTheoTen();
            }
        }

        private void TimKiemSachTheoMa()
        {
            string keywordMa = tb_TimKiemTheoMaSach.Text;
            dataGridSach.ItemsSource = SachBUS.Instance.TimKiemTheoMa(keywordMa);
        }

        private void TimKiemSachTheoTen()
        {
            string keywordTen = tb_TimKiemTheoTenSach.Text;
            dataGridSach.ItemsSource = SachBUS.Instance.TimKiemTheoTen(keywordTen);
        }

        private void tb_TimKiemTheoMaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemSachTheoMa.IsChecked == true)
            {
                TimKiemSachTheoMa();
            }
        }

        private void tb_TimKiemTheoTenSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemSachTheoTen.IsChecked == true)
            {
                TimKiemSachTheoTen();
            }
        }

        private void dataGridSach_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Sach sachDangChon = dataGridSach.SelectedItem as Sach;
            if (sachDangChon == null) return;

            LoadAnhBiaSach(sachDangChon.DuongDanAnh);
            lb_MaSachChon.Content = sachDangChon.pid;
            lb_TenSachChon.Content = sachDangChon.Ten;
            lb_SoLuongTonSachChon.Content = sachDangChon.SoLuongHienCo + "";
            lb_SoLuongMuonSachChon.Content = sachDangChon.SoLuongDaMuon + "";
            tb_MoTaSachChon.Text = sachDangChon.MoTa;
            tb_TacGiaSachChon.Text = sachDangChon.TacGia;
            lb_NamXuatBanSachChon.Content = sachDangChon.NamXB + "";
            lb_NhaXuatBanSachChon.Content = sachDangChon.NhaXuatBan.Ten;
            lb_LoaiSachChon.Content = sachDangChon.LoaiSach1.Ten;
            lb_NganhSachChon.Content = sachDangChon.NganhKhoa1.Ten;
        }

        private void LoadAnhBiaSach(string path)
        {
            try
            {
                this.img_AnhSachChon.Source = new BitmapImage(new Uri(path));
            }
            catch
            {
                this.img_AnhSachChon.Source = new BitmapImage(new Uri("/images/no-image.img", UriKind.Relative));
            }
        }
    }
}
