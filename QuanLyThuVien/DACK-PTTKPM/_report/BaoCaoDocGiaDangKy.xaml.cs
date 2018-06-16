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
using DTO;
using BUS;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for BaoCaoDocGiaDangKy.xaml
    /// </summary>
    public partial class BaoCaoDocGiaDangKy : Page
    {
        public BaoCaoDocGiaDangKy()
        {
            InitializeComponent();
        }

        private void btn_XacNhanBaoCao_Click(object sender, RoutedEventArgs e)
        {
            DateTime begin = (DateTime)dpk_Begin.SelectedDate;
            DateTime end = (DateTime)dpk_End.SelectedDate;
            List<DocGia> dsDocGia = DocGiaBUS.Instance.LayDanhSach(begin, end);

            this.report_BaoCaoDocGiaDangKy.Reset();
            this.report_BaoCaoDocGiaDangKy.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_DocGia", dsDocGia));
            this.report_BaoCaoDocGiaDangKy.LocalReport.ReportEmbeddedResource = "DACK_PTTKPM._report.BaoCaoDocGiaDangKy.rdlc";
            this.report_BaoCaoDocGiaDangKy.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.report_BaoCaoDocGiaDangKy.RefreshReport();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dpk_Begin.SelectedDate = DateTime.Now;
            this.dpk_End.SelectedDate = DateTime.Now;
        }
    }
}
