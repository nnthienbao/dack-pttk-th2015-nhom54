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
                if (instance == null) instance = new DocGiaBUS();
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
    }
}
