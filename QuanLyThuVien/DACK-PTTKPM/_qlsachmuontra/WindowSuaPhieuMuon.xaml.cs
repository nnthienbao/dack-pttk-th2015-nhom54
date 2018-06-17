using DTO;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowSuaPhieuMuon.xaml
    /// </summary>
    public partial class WindowSuaPhieuMuon : Window
    {
        private PhieuMuonSach phieuMuonSach = null;
        private ObservableCollection<ChiTietPhieuMuon> dsChiTietPhieuMuon = null;
        public WindowSuaPhieuMuon(PhieuMuonSach thePhieu)
        {
            this.phieuMuonSach = PhieuMuonSachBUS.Instance.LayPhieuMuonSach(thePhieu.id);
            dsChiTietPhieuMuon = new ObservableCollection<ChiTietPhieuMuon>(this.phieuMuonSach.ChiTietPhieuMuons);
            dsChiTietPhieuMuon.CollectionChanged += DsChiTietPhieuMuon_CollectionChanged;
            foreach(var s in dsChiTietPhieuMuon)
            {
                s.PropertyChanged += SuaPhieuMuon_PropertyChanged;
                //s.PropertyChanging += SuaPhieuMuon_PropertyChanging;
                s.Sach.PropertyChanged += Sach_PropertyChanged;
                s.Sach.PropertyChanging += Sach_PropertyChanging;

            }
            InitializeComponent();
        }

        private void DsChiTietPhieuMuon_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems != null)
            {
                foreach(ChiTietPhieuMuon ctpm in e.NewItems)
                {
                    ctpm.PropertyChanged += SuaPhieuMuon_PropertyChanged;
                    //ctpm.PropertyChanging += SuaPhieuMuon_PropertyChanging;
                    ctpm.Sach = new DTO.Sach(ctpm);
                }
            }
            if (e.OldItems != null)
            {
                foreach (ChiTietPhieuMuon ctpm in e.OldItems)
                {
                    ctpm.Sach.PropertyChanged -= Sach_PropertyChanged;
                    ctpm.Sach.PropertyChanging -= Sach_PropertyChanging;
                    ctpm.PropertyChanged -= SuaPhieuMuon_PropertyChanged;
                    //ctpm.PropertyChanging -= SuaPhieuMuon_PropertyChanging;
                }
            }
        }

        private void Sach_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if(e.PropertyName == nameof(Sach.pid))
            {
                var cancelArgs = e as PropertyChangingCancelEventArgs<string>;

                if (BiTrungSach(cancelArgs.NewValue))
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

        private bool BiTrungSach(string pid)
        {
            foreach (ChiTietPhieuMuon ct in dsChiTietPhieuMuon)
            {
                string pidKt = ct.Sach.pid;
                if (pidKt == null) continue;

                if (pidKt.Equals(pid))
                    return true;
            }
            return false;
        }

        private void Sach_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Sach sach = sender as Sach;
            if (e.PropertyName == nameof(Sach.pid))
            {
                Sach sachMoi = SachBUS.Instance.LaySach(sach.pid);
                int indexSach = dsChiTietPhieuMuon.IndexOf(sach.PhieuMuonRef);
                if (indexSach != -1)
                {
                    dsChiTietPhieuMuon[indexSach].Sach = sachMoi;
                    sachMoi.PhieuMuonRef = dsChiTietPhieuMuon[indexSach];
                }
            }
        }

        //private void SuaPhieuMuon_PropertyChanging(object sender, PropertyChangingEventArgs e)
        //{
        //    ChiTietPhieuMuon ctpm = sender as ChiTietPhieuMuon;
        //    if (e.PropertyName == nameof(ChiTietPhieuMuon.SoLuong))
        //    {
        //        PropertyChangingCancelEventArgs<int> cancelArgs = e as PropertyChangingCancelEventArgs<int>;
        //        int soLuongNhap = cancelArgs.NewValue;
        //        if (soLuongNhap > ctpm.Sach.SoLuongHienCo)
        //        {
        //            datagrid_ChiTietPhieuMuon.CancelEdit();
        //            cancelArgs.Cancel = true;
        //            return;
        //        }
        //    }
        //}

        private void SuaPhieuMuon_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ChiTietPhieuMuon ctpm = sender as ChiTietPhieuMuon;
            ctpm.Sach.PropertyChanged += Sach_PropertyChanged;
            ctpm.Sach.PropertyChanging += Sach_PropertyChanging;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.phieuMuonSach;
            this.datagrid_ChiTietPhieuMuon.ItemsSource = dsChiTietPhieuMuon;

            if(this.phieuMuonSach.TinhTrang == TinhTrangPhieuMuon.DA_TRA)
            {
                btn_TraSach.Visibility = Visibility.Collapsed;
            } else
            {
                btn_HuyTraSach.Visibility = Visibility.Collapsed;
            }
        }

        private void tb_MaDocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                lb_Loi_DocGia.Visibility = Visibility.Hidden;
                DocGia docGiaTemp = phieuMuonSach.DocGia;
                DocGia docGia = DocGiaBUS.Instance.LayDocGia(tb_MaDocGia.Text);
                if (docGia == null)
                {
                    lb_Loi_DocGia.Visibility = Visibility.Visible;
                    tb_MaDocGia.Text = docGiaTemp.mssv;
                }
                else
                {
                    phieuMuonSach.DocGia = docGia;
                }
            }
        }

        private void btn_XacNhan_Click(object sender, RoutedEventArgs e)
        {
            if (!KiemTraDocGiaHopLe()) return;

            var dsChiTietPhieuMuonFinal = KiemTraDSSachMuonHopLe();
            if (dsChiTietPhieuMuonFinal == null) return;

            PhieuMuonSachBUS.Instance.SuaPhieuMuon(phieuMuonSach, dsChiTietPhieuMuonFinal);
            this.DialogResult = true;
            //try
            //{
            //    PhieuMuonSachBUS.Instance.SuaPhieuMuon(phieuMuonSach);
            //    this.DialogResult = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    //MessageBox.Show("Thông báo", "Có lỗi xảy ra với dữ liệu", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private bool KiemTraDocGiaHopLe()
        {
            if (this.phieuMuonSach.DocGia != null) return true;
            MessageBox.Show("Chưa nhập thông tin độc giả", "Thông báo");
            return false;
        }

        private List<ChiTietPhieuMuon> KiemTraDSSachMuonHopLe()
        {
            List<ChiTietPhieuMuon> dsChiTietPhieuMuonFinal = new List<ChiTietPhieuMuon>();
            foreach (ChiTietPhieuMuon ctpm in dsChiTietPhieuMuon)
            {
                if (string.IsNullOrEmpty(ctpm.Sach.pid)) continue;

                if (ctpm.SoLuong == 0)
                {
                    MessageBox.Show("Số lượng mỗi loại sách mượn phải lớn hơn 0", "Thông báo");
                    return null;
                }
                if (!ChiTietPhieuMuonBUS.Instance.KiemTraDuSoLuongMuon(ctpm.MaSach, ctpm.MaPhieuMuon, ctpm.SoLuong))
                {
                    MessageBox.Show("Có một vài sách không đủ số lượng", "Thông báo");
                    return null;
                }
                dsChiTietPhieuMuonFinal.Add(new ChiTietPhieuMuon() { MaSach = ctpm.MaSach, MaPhieuMuon = phieuMuonSach.id, SoLuong = ctpm.SoLuong });
            }
            if (dsChiTietPhieuMuonFinal.Count == 0)
            {
                MessageBox.Show("Chưa nhập sách để mượn", "Thông báo");
                return null;
            }
            return dsChiTietPhieuMuonFinal;
        }

        private void btn_HuyBo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btn_TraSach_Click(object sender, RoutedEventArgs e)
        {
            if(PhieuMuonSachBUS.Instance.TraSach(phieuMuonSach.id))
            {
                MessageBox.Show("Đã trả sách", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            } else
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_HuyTraSach_Click(object sender, RoutedEventArgs e)
        {
            if (PhieuMuonSachBUS.Instance.HuyTraSach(phieuMuonSach.id))
            {
                MessageBox.Show("Đã hủy trả sách", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
