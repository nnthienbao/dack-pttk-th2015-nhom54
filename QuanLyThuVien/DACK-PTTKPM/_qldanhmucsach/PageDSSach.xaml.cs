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
    }
}
