using System;
using System.Collections;
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
        public List<NganhKhoa> LayDanhSach()
        {
            return nsDao.LayDanhSach();
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

        public List<NganhKhoa> TimKiemTheoMa(string keywordMa)
        {
            keywordMa = keywordMa.ToLower();
            return NganhKhoaDAO.Instance.TimKiemTheoMa(keywordMa);
        }

        public List<NganhKhoa> TimKiemTheoTen(string keywordTen)
        {
            keywordTen = keywordTen.ToLower();
            return NganhKhoaDAO.Instance.TimKiemTheoTen(keywordTen);
        }
    }
}
