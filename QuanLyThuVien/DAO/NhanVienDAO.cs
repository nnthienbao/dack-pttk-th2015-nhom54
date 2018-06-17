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
                try
                {
                    nhanVien = db.NhanViens.Single(nv => nv.Disable == false && nv.pid == maNhanVien);
                }
                catch
                {
                    return null;
                }
            }
            return nhanVien;
        }

        public NhanVien Authenticate(string maNhanVien, string matKhau)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                try
                {
                    return db.NhanViens.Select(nv => nv).Single(nv => nv.Disable == false && nv.pid == maNhanVien && nv.MatKhau == matKhau);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
