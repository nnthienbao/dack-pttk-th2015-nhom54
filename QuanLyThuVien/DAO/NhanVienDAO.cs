using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        private NhanVienDAO() { }
        private static NhanVienDAO instance = null;
        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienDAO();
                return instance;
            }
        }

        public NhanVien LayNhanVien(string maNhanVien)
        {
            NhanVien nhanVien = null;
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                nhanVien = db.NhanViens.Single(nv => nv.pid == maNhanVien);
            }
            return nhanVien;
        }
    }
}
