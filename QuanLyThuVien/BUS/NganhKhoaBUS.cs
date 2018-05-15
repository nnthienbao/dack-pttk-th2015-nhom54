using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DAO;
using DTO;

namespace BUS
{
    public class NganhKhoaBUS
    {
        private static NganhKhoaBUS instance = null;

        private NganhKhoaBUS() { }

        public static NganhKhoaBUS Instance
        {
            get
            {
                if (instance == null) instance = new NganhKhoaBUS();
                return instance;
            }
        }

        private NganhKhoaDAO nsDao = NganhKhoaDAO.Instance;
        public void XemDSNGanhSach(DataGrid dtgrid)
        {
            dtgrid.ItemsSource = nsDao.LayDanhSach();
        }

        public void ThemNganhKhoa(String ten)
        {
            nsDao.ThemNganhKhoa(ten);
        }

        public void SuaNganhKhoa(NganhKhoa nganhKhoa)
        {
            nsDao.SuaNganhKhoa(nganhKhoa);
        }

        public void XoaNganhKhoa(string pid)
        {
            nsDao.XoaNganhKhoa(pid);
        }
    }
}
