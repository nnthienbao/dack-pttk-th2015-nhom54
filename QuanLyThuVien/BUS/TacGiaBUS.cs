using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class TacGiaBUS
    {
        private TacGiaBUS() { }
        private static TacGiaBUS instance = null;
        public static TacGiaBUS Instance
        {
            get
            {
                if (instance == null) instance = new TacGiaBUS();
                return instance;
            }
        }
        public List<TacGia> LayDanhSach()
        {
            return TacGiaDAO.Instance.LayDanhSach();
        }

        public void ThemTacGia(string tenTacGia)
        {
            TacGiaDAO.Instance.ThemTacGia(tenTacGia);
        }

        public void SuaTacGia(TacGia tacGia)
        {
            TacGiaDAO.Instance.SuaTacGia(tacGia);
        }

        public void XoaTacGia(string pid)
        {
            TacGiaDAO.Instance.XoaTacGia(pid);
        }
    }
}
