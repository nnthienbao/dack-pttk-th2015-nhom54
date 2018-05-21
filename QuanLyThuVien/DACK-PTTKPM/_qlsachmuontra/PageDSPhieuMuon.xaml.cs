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
        }
    }
}
