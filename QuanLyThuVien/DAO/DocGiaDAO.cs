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

        public void ThemDocGia(DocGia docGia)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                db.DocGias.InsertOnSubmit(docGia);
                db.SubmitChanges();
            }
        }

        public List<DocGia> LayDanhSach()
        {
            List<DocGia> listDocGia = null;

            QLThuVienDataContext db = new QLThuVienDataContext();
            listDocGia = db.DocGias.Select(dg => dg).Where(dg => dg.Disable == false).ToList();

            return listDocGia;
        }
    }
}
