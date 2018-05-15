using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LoaiSachDAO
    {
        private LoaiSachDAO() { }
        private static LoaiSachDAO instance = null;
        public static LoaiSachDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LoaiSachDAO();
                }
                return instance;
            }
        }

        public void ThemNganhKhoa(string ten)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                LoaiSach loaiSachMoi = new LoaiSach
                {
                    Ten = ten
                };
                db.LoaiSaches.InsertOnSubmit(loaiSachMoi);
                db.SubmitChanges();
            }
        }

        public void SuaLoaiSach(LoaiSach loaiSach)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                LoaiSach lsMoi = db.LoaiSaches.Single(ls => ls.pid == loaiSach.pid);
                lsMoi.Ten = loaiSach.Ten;
                db.SubmitChanges();
            }
        }

        public void XoaLoaiSach(string pid)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                LoaiSach lsXoa = db.LoaiSaches.Single(ls => ls.pid == pid);
                lsXoa.Disable = true;
                db.SubmitChanges();
            }
        }

        public List<LoaiSach> LayDanhSach()
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                return db.LoaiSaches.Select(ls => ls).Where(ls => ls.Disable == false).ToList();
            }
        }
    }
}
