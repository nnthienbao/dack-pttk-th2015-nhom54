using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class PhieuMuonSachBUS
    {
        private PhieuMuonSachBUS() { }
        private static PhieuMuonSachBUS instance = null;
        public static PhieuMuonSachBUS Instance
        {
            get
            {
                if (instance == null) instance = new PhieuMuonSachBUS();
                return instance;
            }
        }

        public void ThemPhieuMuon(string nguoiMuon, int nguoiLapPhieu, DateTime ngayMuon, DateTime ngayTra, List<ChiTietPhieuMuon> dsChiTietPhieuMuon)
        {
            PhieuMuonSach phieuMuonSach = new PhieuMuonSach()
            {
                NguoiMuon = nguoiMuon,
                NguoiLapPhieu = nguoiLapPhieu,
                NgayMuon = ngayMuon,
                HanTra = ngayTra
            };

            foreach (ChiTietPhieuMuon ctpm in dsChiTietPhieuMuon)
            {
                ctpm.PhieuMuonSach = phieuMuonSach;
                phieuMuonSach.ChiTietPhieuMuons.Add(ctpm);
            }

            PhieuMuonSachDAO.Instance.ThemPhieuMuon(phieuMuonSach);
        }

        public PhieuMuonSach LayPhieuMuonSach(int id)
        {
            return PhieuMuonSachDAO.Instance.LayPhieuMuonSach(id);
        }

        public List<PhieuMuonSach> LayDanhSach()
        {
            return PhieuMuonSachDAO.Instance.LayDanhSach();
        }

        public void SuaPhieuMuon(PhieuMuonSach phieuMuonSach, List<ChiTietPhieuMuon> dsChiTietPhieuMuonFinal)
        {
            PhieuMuonSachDAO.Instance.SuaPhieuMuon(phieuMuonSach, dsChiTietPhieuMuonFinal);
        }
    }
}
