using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class SachDAO
    {
        private SachDAO() { }
        private static SachDAO instance = null;
        public static SachDAO Instance
        {
            get
            {
                if (instance == null) instance = new SachDAO();
                return instance;
            }
        }

        public void ThemSach(Sach sach)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
            }
        }

        public List<Sach> LayDanhSach()
        {
            List<Sach> sachs = null;
            QLThuVienDataContext db = new QLThuVienDataContext();
            sachs = db.Saches.Select(s => s).Where(s => s.Disable == false).ToList();
            return sachs;
        }
    }
}
