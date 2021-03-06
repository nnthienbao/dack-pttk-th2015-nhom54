﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DocGia.xaml
    /// </summary>
    public partial class PageDSDocGia : Page
    {
        public PageDSDocGia()
        {
            InitializeComponent();
        }

        public void RefreshDanhSach()
        {
            dataGridDocGia.ItemsSource = DocGiaBUS.Instance.LayDanhSach();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }

        public DocGia LayDocGiaDangChon()
        {
            return dataGridDocGia.SelectedItem as DocGia;
        }

        private void btn_TimKiemDocGia_Click(object sender, RoutedEventArgs e)
        {
            if (rd_TimKiemDocGiaTheoMa.IsChecked == true)
            {
                TimKiemDocGiaTheoMa();

            }
            else if (rd_TimKiemDocGiaTheoTen.IsChecked == true)
            {
                TimKiemDocGiaTheoTen();
            }
        }

        private void TimKiemDocGiaTheoMa()
        {
            String keywordMa = tb_TimKiemDocGiaTheoMa.Text;
            dataGridDocGia.ItemsSource = DocGiaBUS.Instance.TimKiemTheoMa(keywordMa);
        }

        private void TimKiemDocGiaTheoTen()
        {
            String keywordTen = tb_TimKiemDocGiaTheoTen.Text;
            dataGridDocGia.ItemsSource = DocGiaBUS.Instance.TimKiemTheoTen(keywordTen);
        }

        private void tb_TimKiemTheoMaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemDocGiaTheoMa.IsChecked == true)
            {
                TimKiemDocGiaTheoMa();
            }
        }

        private void tb_TimKiemTheoTenSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && rd_TimKiemDocGiaTheoTen.IsChecked == true)
            {
                TimKiemDocGiaTheoTen();
            }
        }

        private void dataGridDocGia_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DocGia docGiaDangChon = dataGridDocGia.SelectedItem as DocGia;

            stackpanel_HienThiThongTinDocGia.DataContext = docGiaDangChon;
        }
    }

    public class cvt_booleanToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Boolean)value == true)
            {
                return "Nam";
            }
            return "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as String;
            if (strValue == "Nam")
            {
                return true;
            }
            return false;
        }
    }
}
