﻿using System;
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
    /// Interaction logic for PageDSTacGia.xaml
    /// </summary>
    public partial class PageDSTacGia : Page
    {
        public PageDSTacGia()
        {
            InitializeComponent();
        }

        public void RefreshDanhSach()
        {
            dataGrid_TacGia.ItemsSource = TacGiaBUS.Instance.LayDanhSach();
        }

        public TacGia GetTacGiaDangChon()
        {
            return (TacGia)dataGrid_TacGia.SelectedItem;
        }

        private void dataGrid_TacGia_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDanhSach();
        }
    }
}