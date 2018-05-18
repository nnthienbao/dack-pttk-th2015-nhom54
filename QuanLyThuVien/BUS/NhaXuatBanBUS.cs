using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class NhaXuatBanBUS
    {
        private NhaXuatBanBUS() { }
        private static NhaXuatBanBUS instance = null;
        public static NhaXuatBanBUS Instance
        {
            get
            {
                if (instance == null) instance = new NhaXuatBanBUS();
                return instance;
            }
        }

        public void ThemNhaXuatBan(string tenNXB)
        {
            NhaXuatBanDAO.Instance.ThemNhaXuatBan(tenNXB);
        }

        public List<NhaXuatBan> LayDanhSach()
        {
            return NhaXuatBanDAO.Instance.LayDanhSach();
        }

        public void SuaNhaXuatBan(NhaXuatBan nhaXuatBan)
        {
            NhaXuatBanDAO.Instance.SuaNhaXuatBan(nhaXuatBan);
        }

        public void XoaNhaXuatBan(string pid)
        {
            NhaXuatBanDAO.Instance.XoaNhaXuatBan(pid);
        }

        public List<NhaXuatBan> TimKiemTheoMa(string keywordMa)
        {
            keywordMa = keywordMa.ToLower();
            return NhaXuatBanDAO.Instance.TimKiemTheoMa(keywordMa);
        }

        public List<NhaXuatBan> TimKiemTheoTen(string keywordTen)
        {
            keywordTen = keywordTen.ToLower();
            return NhaXuatBanDAO.Instance.TimKiemTheoTen(keywordTen);
        }
    }
}
