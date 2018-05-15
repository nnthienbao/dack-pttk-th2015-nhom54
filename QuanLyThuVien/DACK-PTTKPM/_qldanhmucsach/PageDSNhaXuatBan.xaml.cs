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
    }
}
