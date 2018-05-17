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
using Microsoft.Win32;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowSuaSach.xaml
    /// </summary>
    public partial class WindowSuaSach : Window
    {
        private Sach sachSua = null;
        public WindowSuaSach(Sach sach)
        {
            this.sachSua = sach;
            InitializeComponent();
        }

        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            panel_Error_TenSach.Visibility = Visibility.Collapsed;
            panel_Error_NamXuatBan.Visibility = Visibility.Collapsed;
            panel_Error_SoLuong.Visibility = Visibility.Collapsed;
            panel_Error_PathAnhBia.Visibility = Visibility.Collapsed;

            string tenSach = tb_TenSach.Text;
            LoaiSach loaiSach = (LoaiSach)cbb_LoaiSach.SelectedItem;
            NganhKhoa nganh = (NganhKhoa)cbb_Nganh.SelectedItem;
            TacGia tacGia = (TacGia)cbb_TacGia.SelectedItem;
            NhaXuatBan nhaXuatBan = (NhaXuatBan)cbb_NhaXuatBan.SelectedItem;
            int namXuatBan = tbNumber_NamXuatBan.Number;
            int soLuongTon = tbNumber_SoLuongTon.Number;
            int soLuongMuon = tbNumber_SoLuongMuon.Number;
            string moTa = tb_MoTa.Text;
            string duongDanAnh = tb_DuongDanAnhMinhHoa.Text;

            bool error = false;
            if (string.IsNullOrEmpty(tenSach))
            {
                panel_Error_TenSach.Visibility = Visibility.Visible;
                error = true;
            }

            if (namXuatBan == 0)
            {
                panel_Error_NamXuatBan.Visibility = Visibility.Visible;
                error = true;
            }

            if (string.IsNullOrEmpty(duongDanAnh))
            {
                panel_Error_PathAnhBia.Visibility = Visibility.Visible;
                error = true;
            }

            if (error) return;

            Sach sach = new Sach
            {
                id = sachSua.id,
                Ten = tenSach,
                TacGia = tacGia.id,
                NamXB = namXuatBan,
                NhaXB = nhaXuatBan.id,
                MoTa = moTa,
                LoaiSach = loaiSach.id,
                NganhKhoa = nganh.id,
                DuongDanAnh = sachSua.DuongDanAnh,
                SoLuongHienCo = soLuongTon,
                SoLuongDaMuon = soLuongMuon
            };
            try
            {
                SachBUS.Instance.SuaSach(sach, duongDanAnh);
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra !", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbb_LoaiSach.ItemsSource = LoaiSachBUS.Instance.LayDanhSach();
            this.cbb_Nganh.ItemsSource = NganhKhoaBUS.Instance.LayDanhSach();
            this.cbb_TacGia.ItemsSource = TacGiaBUS.Instance.LayDanhSach();
            this.cbb_NhaXuatBan.ItemsSource = NhaXuatBanBUS.Instance.LayDanhSach();

            this.tb_MaSach.Text = sachSua.pid;
            this.tb_TenSach.Text = sachSua.Ten;
            this.cbb_LoaiSach.SelectedValue = sachSua.LoaiSach1.id;
            this.cbb_Nganh.SelectedValue = sachSua.NganhKhoa1.id;
            this.cbb_TacGia.SelectedValue = sachSua.TacGia1.id;
            this.cbb_NhaXuatBan.SelectedValue = sachSua.NhaXuatBan.id;
            this.tbNumber_NamXuatBan.Number = (int)sachSua.NamXB;
            this.tbNumber_SoLuongTon.Number = (int)sachSua.SoLuongHienCo;
            this.tbNumber_SoLuongMuon.Number = (int)sachSua.SoLuongDaMuon;
            this.tb_MoTa.Text = sachSua.MoTa;
            this.tb_DuongDanAnhMinhHoa.Text = sachSua.DuongDanAnh;
            this.img_AnhMinhHoa.Source = this.img_AnhMinhHoa.Source = new BitmapImage(new Uri(sachSua.DuongDanAnh));
        }

        private void btn_ChonAnhMinhHoa_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                panel_Error_PathAnhBia.Visibility = Visibility.Collapsed;
                string imgPath = ofd.FileName;
                try
                {
                    this.img_AnhMinhHoa.Source = new BitmapImage(new Uri(imgPath));
                    this.tb_DuongDanAnhMinhHoa.Text = imgPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không hỗ trợ định dàng này", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
