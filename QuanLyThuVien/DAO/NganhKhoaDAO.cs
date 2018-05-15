using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NganhKhoaDAO
    {
        private static NganhKhoaDAO instance = null;
        private NganhKhoaDAO() { }

        public static NganhKhoaDAO Instance
        {
            get {
                if(instance == null)
                {
                    instance = new NganhKhoaDAO();
                }
                return instance;
            }
        }

        public List<NganhKhoa> LayDanhSach()
        {
            List<NganhKhoa> nganhKhoas = new List<NganhKhoa>();
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                nganhKhoas = db.NganhKhoas.Select(nk => nk).ToList();
            }

            return nganhKhoas;
        }

        public void ThemNganhKhoa(String ten)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                NganhKhoa nk = new NganhKhoa
                {
                    Ten = ten
                };

                db.NganhKhoas.InsertOnSubmit(nk);

                db.SubmitChanges();
            }
        }

        public void SuaNganhKhoa(NganhKhoa nganhKhoa)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                NganhKhoa nkMoi = db.NganhKhoas.Single(nk => nk.pid == nganhKhoa.pid);
                nkMoi.Ten = nganhKhoa.Ten;
                db.SubmitChanges();
            }
        }
    }
}
