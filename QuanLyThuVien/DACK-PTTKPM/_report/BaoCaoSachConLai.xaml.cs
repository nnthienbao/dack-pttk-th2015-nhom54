using BUS;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DACK_PTTKPM
{
    /// <summary>
    /// Interaction logic for ThongKeSachConLai.xaml
    /// </summary>
    public partial class BaoCaoSachConLai : Page
    {
        public BaoCaoSachConLai()
        {
            InitializeComponent();
        }

        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
            List<Sach> dsSach = SachBUS.Instance.LayDanhSach();

            this.report_ThongKeSachConLai.Reset();
            this.report_ThongKeSachConLai.LocalReport.DataSources
                .Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet_Sach", dsSach));
            this.report_ThongKeSachConLai.LocalReport.ReportEmbeddedResource = "DACK_PTTKPM._report.BaoCaoSachConLai.rdlc";
            this.report_ThongKeSachConLai.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.report_ThongKeSachConLai.RefreshReport();
        }
    }
}
