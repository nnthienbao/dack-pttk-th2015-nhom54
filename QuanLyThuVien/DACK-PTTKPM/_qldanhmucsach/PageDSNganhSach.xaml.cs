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
using System.Collections;
using DTO;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for NganhSach.xaml
    /// </summary>
    public partial class PageDSNganhSach : Page
    {
        public PageDSNganhSach()
        {
            InitializeComponent();
        }

        private NganhKhoaBUS nsBus = NganhKhoaBUS.Instance;
        private void dataGridNganhSach_Loaded(object sender, RoutedEventArgs e)
        {
            refreshDanhSach();
        }

        public NganhKhoa getNganhDangChon()
        {
            NganhKhoa nganhKhoa = (NganhKhoa)dataGridNganhSach.SelectedItem;
            return nganhKhoa;
        }

        public void refreshDanhSach()
        {
            this.dataGridNganhSach.ItemsSource = nsBus.LayDanhSach();
        }

        private void tb_TimKiemNganhSachTheoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && rd_TimKiemNganhSachTheoMaNganh.IsChecked == true)
            {
                TimKiemNganhSachTheoMa();
            }
        }

        private void tb_TimKiemNganhSachTheoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemNganhSachTheoTen.IsChecked == true)
            {
                TimKiemNganhSachTheoTen();
            }
        }

        private void btn_TimKiemNganhSach_Click(object sender, RoutedEventArgs e)
        {
            if(rd_TimKiemNganhSachTheoMaNganh.IsChecked == true)
            {
                TimKiemNganhSachTheoMa();
            } else if(rd_TimKiemNganhSachTheoTen.IsChecked == true)
            {
                TimKiemNganhSachTheoTen();
            }
        }

        private void TimKiemNganhSachTheoMa()
        {
            string keywordMa = tb_TimKiemNganhSachTheoMa.Text;
            dataGridNganhSach.ItemsSource = NganhKhoaBUS.Instance.TimKiemTheoMa(keywordMa);
        }

        private void TimKiemNganhSachTheoTen()
        {
            string keywordTen = tb_TimKiemNganhSachTheoTen.Text;
            dataGridNganhSach.ItemsSource = NganhKhoaBUS.Instance.TimKiemTheoTen(keywordTen);
        }

        private void dataGridNganhSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NganhKhoa nganhDangChon = dataGridNganhSach.SelectedItem as NganhKhoa;
            if (nganhDangChon == null) return;

            lb_MaNganhSachChon.Content = nganhDangChon.pid;
            lb_TenNganhSachChon.Content = nganhDangChon.Ten;
        }
    }
}
