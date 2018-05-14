using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DAO;

namespace BUS
{
    public class NganhKhoaBUS
    {
        private NganhKhoaDAO nsDao = new NganhKhoaDAO();
        public void XemDSNGanhSach(DataGrid dtgrid)
        {
            dtgrid.ItemsSource = nsDao.LayDanhSach();
        }
    }
}
