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
    /// Interaction logic for BaoCaoDocGiaViPham.xaml
    /// </summary>
    public partial class BaoCaoDocGiaViPham : Page
    {
        public BaoCaoDocGiaViPham()
        {
            InitializeComponent();
        }

        private void btn_XacNhanBaoCao_Click(object sender, RoutedEventArgs e)
        {
            DateTime begin = (DateTime) dpk_Begin.SelectedDate;
            DateTime end = (DateTime)dpk_End.SelectedDate;
            List<DocGiaViPham> dsDGViPham = DocGiaBUS.Instance.LayDanhSachViPham(begin, end);

            this.report_BaoCaoDocGiaViPham.Reset();
            this.report_BaoCaoDocGiaViPham.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_DocGiaViPham", dsDGViPham));
            this.report_BaoCaoDocGiaViPham.LocalReport.ReportEmbeddedResource = "DACK_PTTKPM._report.BaoCaoDocGiaViPham.rdlc";
            this.report_BaoCaoDocGiaViPham.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.report_BaoCaoDocGiaViPham.RefreshReport();
        }
    }
}
