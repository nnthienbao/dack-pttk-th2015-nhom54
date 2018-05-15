using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TacGiaDAO
    {
        private TacGiaDAO() { }
        private static TacGiaDAO instance = null;
        public static TacGiaDAO Instance
        {
            get
            {
                if (instance == null) instance = new TacGiaDAO();
                return instance;
            }
        }
        public List<TacGia> LayDanhSach()
        {
            List<TacGia> tacGias;
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                tacGias = db.TacGias.Select(tg => tg).Where(tg => tg.Disable == false).ToList();
            }

            return tacGias;
        }

        public void ThemTacGia(string tenTacGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                TacGia tacGia = new TacGia
                {
                    Ten = tenTacGia
                };

                db.TacGias.InsertOnSubmit(tacGia);
                db.SubmitChanges();
            }
        }

        public void XoaTacGia(string pid)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                TacGia tgXoa = db.TacGias.Single(tg => tg.pid == pid);
                tgXoa.Disable = true;
                db.SubmitChanges();
            }
        }

        public void SuaTacGia(TacGia tacGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                TacGia tgMoi = db.TacGias.Single(tg => tg.pid == tacGia.pid);
                tgMoi.Ten = tacGia.Ten;
                db.SubmitChanges();
            }
        }
    }
}
