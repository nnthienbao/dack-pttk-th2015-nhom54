using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class PhieuMuonSachDAO
    {
        private PhieuMuonSachDAO() { }
        private static PhieuMuonSachDAO instance = null;
        public static PhieuMuonSachDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhieuMuonSachDAO();
                return instance;
            }
        }

        public void ThemPhieuMuon(PhieuMuonSach phieuMuonsach)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                db.PhieuMuonSaches.InsertOnSubmit(phieuMuonsach);
                foreach(ChiTietPhieuMuon ctpm in phieuMuonsach.ChiTietPhieuMuons)
                {
                    Sach sach = db.Saches.Single(s => s.id == ctpm.MaSach);
                    sach.SoLuongHienCo -= ctpm.SoLuong;
                    sach.SoLuongDaMuon += ctpm.SoLuong;
                }
                db.SubmitChanges();
            }
        }

        public List<PhieuMuonSach> LayDanhSach()
        {
            List<PhieuMuonSach> dsPhieu = null;
            QLThuVienDataContext db = new QLThuVienDataContext();
            dsPhieu = db.PhieuMuonSaches.Select(p => p).Where(p => p.Disable == false).ToList();
            return dsPhieu;
        }
    }
}