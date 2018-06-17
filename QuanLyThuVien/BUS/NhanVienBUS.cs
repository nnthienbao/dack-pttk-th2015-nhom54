using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienBUS() { }
        private static NhanVienBUS instance = null;
        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienBUS();
                return instance;
            }
        }

        public NhanVien LayNhanVien(string maNhanVien)
        {
            return NhanVienDAO.Instance.LayNhanVien(maNhanVien);
        }

        public NhanVien Authenticate(string maNhanVien, string matKhau)
        {
            return NhanVienDAO.Instance.Authenticate(maNhanVien, matKhau);
        }
    }
}
