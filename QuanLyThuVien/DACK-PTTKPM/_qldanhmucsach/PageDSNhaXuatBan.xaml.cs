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

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for NhaXuatBan.xaml
    /// </summary>
    public partial class PageDSNhaXuatBan : Page
    {
        public PageDSNhaXuatBan()
        {
            InitializeComponent();
        }

        public void RefreshDanhSach()
        {
            dataGridNhaXuatBan.ItemsSource = NhaXuatBanBUS.Instance.LayDanhSach();
        }

        private void dataGridNhaXuatBan_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }

        public NhaXuatBan GetNhaXuatBanDangChon()
        {
            return (NhaXuatBan)dataGridNhaXuatBan.SelectedItem;
        }

        private void tb_TimKiemNXBTheoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && rd_TimKiemNXBTheoMa.IsChecked == true)
            {
                TimKiemNXBTheoMa();
            }
        }

        private void TimKiemNXBTheoMa()
        {
            string keywordMa = tb_TimKiemNXBTheoMa.Text;
            dataGridNhaXuatBan.ItemsSource = NhaXuatBanBUS.Instance.TimKiemTheoMa(keywordMa);
        }

        private void tb_TimKiemNXBTheoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemNXBTheoTen.IsChecked == true)
            {
                TimKiemNXBTheoTen();
            }
        }

        private void TimKiemNXBTheoTen()
        {
            string keywordTen = tb_TimKiemNXBTheoTen.Text;
            dataGridNhaXuatBan.ItemsSource = NhaXuatBanBUS.Instance.TimKiemTheoTen(keywordTen);
        }

        private void btn_TimKiemNXB_Click(object sender, RoutedEventArgs e)
        {
            if(rd_TimKiemNXBTheoMa.IsChecked == true)
            {
                TimKiemNXBTheoMa();
            } else if(rd_TimKiemNXBTheoTen.IsChecked == true)
            {
                TimKiemNXBTheoTen();
            }
        }

        private void dataGridNhaXuatBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NhaXuatBan nxbDangChon = dataGridNhaXuatBan.SelectedItem as NhaXuatBan;
            if (nxbDangChon == null) return;

            lb_MaNXBChon.Content = nxbDangChon.pid;
            lb_TenNXBChon.Content = nxbDangChon.Ten;
        }
    }
}
