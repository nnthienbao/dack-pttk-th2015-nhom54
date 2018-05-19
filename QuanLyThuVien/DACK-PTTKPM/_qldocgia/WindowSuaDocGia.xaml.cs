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
using System.Windows.Shapes;
using BUS;
using DTO;


namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowSuaDocGia.xaml
    /// </summary>
    public partial class WindowSuaDocGia : Window
    {
        DocGia docGia = null;

        public WindowSuaDocGia()
        {
            InitializeComponent();
        }

        public WindowSuaDocGia(DocGia docGia)
        {
            this.docGia = docGia;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
