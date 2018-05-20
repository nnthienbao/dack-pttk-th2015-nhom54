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
                if (instance == null) instance = new DocGiaDAO();
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
    }
}
