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
    }
}
