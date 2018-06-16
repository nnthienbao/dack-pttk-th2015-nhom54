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
    /// Interaction logic for BaoCaoSachMuon.xaml
    /// </summary>
    public partial class BaoCaoSachMuon : Page
    {
        public BaoCaoSachMuon()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_XacNhanBaoCao_Click(object sender, RoutedEventArgs e)
        {
            DateTime begin = (DateTime)dpk_Begin.SelectedDate;
            DateTime end = (DateTime)dpk_End.SelectedDate;

            List<SoLuongSachMuon> dsSLSachMuon = SachBUS.Instance.LayDanhSachSachMuon(begin, end);

            this.report_BaoCaoMuonSach.Reset();
            this.report_BaoCaoMuonSach.LocalReport.DataSources
                .Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_SoLuongSachMuon", dsSLSachMuon));
            this.report_BaoCaoMuonSach.LocalReport.ReportEmbeddedResource = "DACK_PTTKPM._report.BaoCaoSachMuon.rdlc";
            this.report_BaoCaoMuonSach.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.report_BaoCaoMuonSach.RefreshReport();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dpk_Begin.SelectedDate = DateTime.Now;
            this.dpk_End.SelectedDate = DateTime.Now;
        }
    }
}
