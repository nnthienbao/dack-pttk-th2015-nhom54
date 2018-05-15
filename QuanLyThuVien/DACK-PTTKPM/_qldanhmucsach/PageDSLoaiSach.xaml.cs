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
    }
}
