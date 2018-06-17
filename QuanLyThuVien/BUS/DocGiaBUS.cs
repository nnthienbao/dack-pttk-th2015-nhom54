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
        
        public DocGia LayDocGia(string maDocGia)
        {
            try
            {
                return DocGiaDAO.Instance.LayDocGia(maDocGia);
            }
            catch
            {
                return null;
            }
        }
        
        public List<DocGia> LayDanhSach()
        { 
            return DocGiaDAO.Instance.LayDanhSach();
        }

        public List<DocGia> LayDanhSach(DateTime begin, DateTime end)
        {
            return DocGiaDAO.Instance.LayDanhSach(begin, end);
        }

        public List<DocGiaViPham> LayDanhSachViPham(DateTime begin, DateTime end)
        {
            return DocGiaDAO.Instance.LayDanhSachViPham(begin, end);
        }

        public void ThemDocGia(DocGia docGia)
        {
            DocGiaDAO.Instance.ThemDocGia(docGia);
        }

        public void SuaDocGia(DocGia docGia)
        {
            DocGiaDAO.Instance.SuaDocGia(docGia);
        }

        public void XoaDocGia(String maDocGia)
        {
            DocGiaDAO.Instance.XoaDocGia(maDocGia);
        }

        public List<DocGia> TimKiemTheoMa(String maDocGia)
        {
            return DocGiaDAO.Instance.TimKiemTheoMa(maDocGia);
        }

        public List<DocGia> TimKiemTheoTen(String tenDocGia)
        {
            return DocGiaDAO.Instance.TimKiemTheoTen(tenDocGia);
        }
    }
}