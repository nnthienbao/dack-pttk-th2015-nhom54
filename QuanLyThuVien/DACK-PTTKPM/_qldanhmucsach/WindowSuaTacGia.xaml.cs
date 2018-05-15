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
using DTO;
using BUS;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowSuaTacGia.xaml
    /// </summary>
    public partial class WindowSuaTacGia : Window
    {
        private TacGia tacGia;
        public WindowSuaTacGia(TacGia tacGia)
        {
            this.tacGia = tacGia;
            InitializeComponent();
        }

        private string tenTacGiaCu = "";
        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            lb_Loi_TenTacGia.Content = "";
            string tenTacGiaMoi = tb_TenTacGia.Text;

            if(string.IsNullOrEmpty(tenTacGiaMoi))
            {
                lb_Loi_TenTacGia.Content = "Tên tác giả không được để trống";
            } else
            {
                tenTacGiaCu = tacGia.Ten;
                tacGia.Ten = tenTacGiaMoi;
                try
                {
                    TacGiaBUS.Instance.SuaTacGia(tacGia);
                    this.DialogResult = true;
                } catch (Exception ex)
                {
                    tacGia.Ten = tenTacGiaCu;
                    lb_Loi_TenTacGia.Content = "Tên tác giả phải từ 1-50 ký tự";
                }
            }
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tb_MaTacGia.Text = tacGia.pid;
            tb_TenTacGia.Text = tacGia.Ten;
        }
    }
}
