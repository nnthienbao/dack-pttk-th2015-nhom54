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
using System.Windows.Shapes;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for WindowSuaNhaXuatBan.xaml
    /// </summary>
    public partial class WindowSuaNhaXuatBan : Window
    {
        public WindowSuaNhaXuatBan()
        {
            InitializeComponent();
        }

        private void btnXacNhanClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnHuyBoClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
