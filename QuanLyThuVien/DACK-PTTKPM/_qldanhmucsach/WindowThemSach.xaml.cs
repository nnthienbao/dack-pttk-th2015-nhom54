using Microsoft.Win32;
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

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowThemSach.xaml
    /// </summary>
    public partial class WindowThemSach : Window
    {
        public WindowThemSach()
        {
            InitializeComponent();
        }

        private void btn_ChonAnhMinhHoa_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if(ofd.ShowDialog() == true)
            {
                string imgPath = ofd.FileName;
                try
                {
                    this.img_AnhMinhHoa.Source = new BitmapImage(new Uri(imgPath));
                    this.tb_DuongDanAnhMinhHoa.Text = imgPath;
                } catch (Exception ex)
                {
                    MessageBox.Show("Không hỗ trợ định dàng này", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
