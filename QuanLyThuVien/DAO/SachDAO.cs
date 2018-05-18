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

        public void SuaSach(Sach sach)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                Sach sachSua = db.Saches.Single(s => s.id == sach.id);

                sachSua.Ten = sach.Ten;
                sachSua.LoaiSach = sach.LoaiSach;
                sachSua.NganhKhoa = sach.NganhKhoa;
                sachSua.TacGia = sach.TacGia;
                sachSua.NhaXB = sach.NhaXB;
                sachSua.NamXB = sach.NamXB;
                sachSua.SoLuongHienCo = sach.SoLuongHienCo;
                sachSua.SoLuongDaMuon = sach.SoLuongDaMuon;
                sachSua.MoTa = sach.MoTa;
                sachSua.DuongDanAnh = sach.DuongDanAnh;

                db.SubmitChanges();
            }
        }

        public List<Sach> TimKiemTheoTen(string keywordTen)
        {
            List<Sach> sachs = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            sachs = db.Saches.Select(s => s).Where(s => s.Ten.ToLower().Contains(keywordTen)).ToList();

            return sachs;
        }

        public List<Sach> TimKiemTheoMa(string keywordMa)
        {
            List<Sach> sachs = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            sachs = db.Saches.Select(s => s).Where(s => s.pid.ToLower().Contains(keywordMa)).ToList();

            return sachs;
        }

        public void XoaSach(int id)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                Sach sachXoa = db.Saches.Single(s => s.id == id);
                sachXoa.Disable = true;
                db.SubmitChanges();
            }
        }
    }
}
