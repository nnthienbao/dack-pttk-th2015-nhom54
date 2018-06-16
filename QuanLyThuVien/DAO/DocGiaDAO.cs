using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DocGiaDAO
    {
        private DocGiaDAO() { }
        private static DocGiaDAO instance = null;
        
        public static DocGiaDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DocGiaDAO();
                }
                return instance;
            }
        }  

        public DocGia LayDocGia(string maDocGia)
        {
            DocGia docGia = null;
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                docGia = db.DocGias.Single(dg => dg.mssv == maDocGia);
            }
            return docGia;
        }
        
        public List<DocGia> LayDanhSach()
        {
            List<DocGia> listDocGia = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            listDocGia = db.DocGias.Select(dg => dg).Where(dg => dg.Disable == false).ToList();

            return listDocGia;
        }

        public void ThemDocGia(DocGia docGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                db.DocGias.InsertOnSubmit(docGia);
                db.SubmitChanges();
            }
        }

        public void SuaDocGia(DocGia docGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                DocGia docGiaSua = db.DocGias.Single(dg => dg.mssv == docGia.mssv);

                docGiaSua.HoTen = docGia.HoTen;
                docGiaSua.GioiTinh = docGia.GioiTinh;
                docGiaSua.NgaySinh = docGia.NgaySinh;

                db.SubmitChanges();
            }
        }

        public void XoaDocGia(String maDocGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                DocGia docGiaXoa = db.DocGias.Single(s => s.mssv == maDocGia);
                docGiaXoa.Disable = true;
                db.SubmitChanges();
            }
        }

        public List<DocGia> TimKiemTheoMa(String keywordMa)
        {
            List<DocGia> docgias = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            docgias = db.DocGias.Select(dg => dg).Where(dg => dg.Disable == false && dg.mssv.ToLower().Contains(keywordMa)).ToList();

            return docgias;
        }

        public List<DocGia> TimKiemTheoTen(String keywordTen)
        {
            List<DocGia> docgias = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            docgias = db.DocGias.Select(dg => dg).Where(dg => dg.Disable == false && dg.HoTen.ToLower().Contains(keywordTen)).ToList();

            return docgias;
        }
    }
}

