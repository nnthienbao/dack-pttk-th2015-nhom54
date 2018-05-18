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
    /// Interaction logic for LoaiSach.xaml
    /// </summary>
    public partial class PageDSLoaiSach : Page
    {
        public PageDSLoaiSach()
        {
            InitializeComponent();
        }



        public void RefreshDanhSach()
        {
            dataGridLoaiSach.ItemsSource = LoaiSachBUS.Instance.LayDanhSach();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }

        public LoaiSach GetLoaiSachDangChon()
        {
            return (LoaiSach)dataGridLoaiSach.SelectedItem;
        }

        private void tb_TimKiemTheoMaLoaiSach_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && rd_TimKiemLoaiSachTheoMa.IsChecked == true)
            {
                TimKiemLoaiSachTheoMa();
            }
        }

        private void tb_TimKiemTheoTenLoaiSach_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && rd_TimKiemLoaiSachTheoTen.IsChecked == true)
            {
                TimKiemLoaiSachTheoTen();
            }
        }

        private void btn_TimKiemLoaiSach_Click(object sender, RoutedEventArgs e)
        {
            if(rd_TimKiemLoaiSachTheoMa.IsChecked == true)
            {
                TimKiemLoaiSachTheoMa();
            } else if(rd_TimKiemLoaiSachTheoTen.IsChecked == true)
            {
                TimKiemLoaiSachTheoTen();
            }
        }

        private void TimKiemLoaiSachTheoTen()
        {
            string keywordTen = tb_TimKiemTheoTenLoaiSach.Text;
            dataGridLoaiSach.ItemsSource = LoaiSachBUS.Instance.TimKiemTheoTen(keywordTen);
        }

        private void TimKiemLoaiSachTheoMa()
        {
            string keywordMa = tb_TimKiemTheoMaLoaiSach.Text;
            dataGridLoaiSach.ItemsSource = LoaiSachBUS.Instance.TimKiemTheoMa(keywordMa);
        }

        private void dataGridLoaiSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoaiSach loaiSachDangChon = dataGridLoaiSach.SelectedItem as LoaiSach;
            if (loaiSachDangChon == null) return;

            this.lb_MaLoaiSachChon.Content = loaiSachDangChon.pid;
            this.lb_TenLoaiSachChon.Content = loaiSachDangChon.Ten;
        }
    }
}
