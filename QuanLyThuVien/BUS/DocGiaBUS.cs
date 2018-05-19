using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;


namespace BUS
{
    public class DocGiaBUS
    {
        private DocGiaBUS() { }
        private static DocGiaBUS instance = null;
        public static DocGiaBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DocGiaBUS();
                }
                return instance;
            }
        }

        public void ThemDocGia(DocGia docGia)
        {
            DocGiaDAO.Instance.ThemDocGia(docGia);
        }

        public List<DocGia> LayDanhSach()
        { 
            return DocGiaDAO.Instance.LayDanhSach();
        }
    }
}
