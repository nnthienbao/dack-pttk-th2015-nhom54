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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Linq;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowThemPhieuMuon.xaml
    /// </summary>
    public partial class WindowThemPhieuMuon : Window
    {
        private DocGia docGia = null;
        private ObservableCollection<ChiTietPhieuMuon> dsChiTietPhieuMuon = new ObservableCollection<ChiTietPhieuMuon>();
        private NhanVien nguoiLapPhieu = MainWindow.NhanVienSuDung;
        private DateTime ngayMuon = DateTime.Now;
        private DateTime ngayTra;

        public WindowThemPhieuMuon()
        {
            InitializeComponent();
        }

        private void tb_MaDocGia_KeyDown(object sender, KeyEventArgs e)
        {
            docGia = null;
            if(e.Key == Key.Return)
            {
                string maDocGia = tb_MaDocGia.Text;
                docGia = DocGiaBUS.Instance.LayDocGia(maDocGia);
                if (docGia == null)
                {
                    lb_Loi_DocGia.Visibility = Visibility.Visible;
                    return;
                }
                lb_Loi_DocGia.Visibility = Visibility.Hidden;

                lb_HoTenDocGia.Content = docGia.HoTen;
                lb_NgaySinh.Content = String.Format("{0:dd/MM/yyyy}", docGia.NgaySinh);
                lb_GioiTinh.Content = docGia.GioiTinh == true ? "Nam" : "Nữ";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ngayTra = ngayMuon.AddDays(14d);

            lb_NgayMuon.Content = string.Format("{0:dd/MM/yyyy}", ngayMuon);
            lb_NgayTra.Content = string.Format("{0:dd/MM/yyyy}", ngayTra);
            lb_TenNguoiLapPhieu.Content = nguoiLapPhieu.Ten;

            datagrid_ChiTietPhieuMuon.ItemsSource = dsChiTietPhieuMuon;
            
            dsChiTietPhieuMuon.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(DataGrid_ChiTietPhieuMuon_DataChanged);
        }

        private void DataGrid_ChiTietPhieuMuon_DataChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
            {
                foreach(Object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(ChiTietPhieuMuon_PropertyChanged);
                    (item as INotifyPropertyChanging).PropertyChanging += new PropertyChangingEventHandler(ChiTietPhieuMuon_PropertyChanging);
                    (item as ChiTietPhieuMuon).Sach = new Sach(item as ChiTietPhieuMuon);
                }
            }

            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    ((item as ChiTietPhieuMuon).Sach).PropertyChanged -= new PropertyChangedEventHandler(ChiTietPhieuMuon_Sach_PropertyChanged);
                    ((item as ChiTietPhieuMuon).Sach).PropertyChanging -= new PropertyChangingEventHandler(ChiTietPhieuMuon_Sach_PropertyChanging);
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(ChiTietPhieuMuon_PropertyChanged);
                    (item as INotifyPropertyChanging).PropertyChanging -= new PropertyChangingEventHandler(ChiTietPhieuMuon_PropertyChanging);
                }
            }
        }

        private void ChiTietPhieuMuon_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            ChiTietPhieuMuon ctpm = sender as ChiTietPhieuMuon;
            if (e.PropertyName == nameof(ChiTietPhieuMuon.Sach))
            {
                ctpm.Sach.PropertyChanged += new PropertyChangedEventHandler(ChiTietPhieuMuon_Sach_PropertyChanged);
                ctpm.Sach.PropertyChanging += new PropertyChangingEventHandler(ChiTietPhieuMuon_Sach_PropertyChanging);
            }
            
        }

        private void ChiTietPhieuMuon_PropertyChanging(Object sender, PropertyChangingEventArgs e)
        {
            ChiTietPhieuMuon ctpm = sender as ChiTietPhieuMuon;
            if(e.PropertyName == nameof(ChiTietPhieuMuon.SoLuong))
            {

                PropertyChangingCancelEventArgs<int> cancelArgs = e as PropertyChangingCancelEventArgs<int>;
                int soLuongNhap = cancelArgs.NewValue;
                if(soLuongNhap > ctpm.Sach.SoLuongHienCo)
                {
                    datagrid_ChiTietPhieuMuon.CancelEdit();
                    cancelArgs.Cancel = true;
                    return;
                }
            }
        }

        private void ChiTietPhieuMuon_Sach_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            Sach sach = sender as Sach;
            if (e.PropertyName == nameof(Sach.pid))
            {
                Sach sachMoi = SachBUS.Instance.LaySach(sach.pid);
                int indexSach = dsChiTietPhieuMuon.IndexOf(sach.PhieuMuonRef);
                if (sachMoi != null)
                {
                    if (indexSach != -1)
                    {
                        dsChiTietPhieuMuon[indexSach].Sach = sachMoi;
                        sachMoi.PhieuMuonRef = dsChiTietPhieuMuon[indexSach];
                    }
                }
            }
        }

        private void ChiTietPhieuMuon_Sach_PropertyChanging(Object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == nameof(Sach.pid))
            {
                lb_ThongBaoLoiThemSach.Content = "";

                PropertyChangingCancelEventArgs<string> cancelArgs = e as PropertyChangingCancelEventArgs<string>;

                if(BiTrungSach(cancelArgs.NewValue))
                {
                    lb_ThongBaoLoiThemSach.Content = "Sách đã được thêm";
                    datagrid_ChiTietPhieuMuon.CancelEdit();
                    cancelArgs.Cancel = true;
                    return;
                }

                Sach sachTim = SachBUS.Instance.LaySach(cancelArgs.NewValue);

                if(sachTim == null)
                {
                    lb_ThongBaoLoiThemSach.Content = "Không tìm thấy sách";
                    datagrid_ChiTietPhieuMuon.CancelEdit();
                    cancelArgs.Cancel = true;
                }
            }
        }

        private bool BiTrungSach(string pidSachMoi)
        {
            foreach(ChiTietPhieuMuon ct in dsChiTietPhieuMuon)
            {
                string pidKt = ct.Sach.pid;
                if (pidKt == null) continue;

                if (pidKt.Equals(pidSachMoi))
                    return true;
            }
            return false;
        }

        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraDocGiaHopLe()) return;

            var dsChiTietPhieuMuonFinal = KiemTraDSSachMuonHopLe();
            if (dsChiTietPhieuMuonFinal == null) return;

            try
            {
                PhieuMuonSachBUS.Instance.ThemPhieuMuon(docGia.mssv, nguoiLapPhieu.id, ngayMuon, ngayTra, dsChiTietPhieuMuonFinal);
                this.DialogResult = true;
            } catch (Exception ex)
            {
                MessageBox.Show("Thông báo", "Có lỗi xảy ra với dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<ChiTietPhieuMuon> KiemTraDSSachMuonHopLe()
        {
            List<ChiTietPhieuMuon> dsChiTietPhieuMuonFinal = new List<ChiTietPhieuMuon>();
            foreach(ChiTietPhieuMuon phieuMuon in dsChiTietPhieuMuon)
            {
                if (string.IsNullOrEmpty(phieuMuon.Sach.pid)) continue;

                if(phieuMuon.SoLuong == 0)
                {
                    MessageBox.Show("Số lượng mỗi loại sách mượn phải lớn hơn 0", "Thông báo");
                    return null;
                }
                if(phieuMuon.SoLuong > phieuMuon.Sach.SoLuongHienCo)
                {
                    MessageBox.Show("Có một vài sách không đủ số lượng", "Thông báo");
                    return null;
                }
                dsChiTietPhieuMuonFinal.Add(new ChiTietPhieuMuon() { MaSach = phieuMuon.MaSach, SoLuong = phieuMuon.SoLuong });
            }
            if (dsChiTietPhieuMuonFinal.Count == 0)
            {
                MessageBox.Show("Chưa nhập sách để mượn", "Thông báo");
                return null;
            }
            return dsChiTietPhieuMuonFinal;
        }

        private bool KiemTraDocGiaHopLe()
        {
            if (this.docGia != null) return true;
            MessageBox.Show("Chưa nhập thông tin độc giả", "Thông báo");
            return false;
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
