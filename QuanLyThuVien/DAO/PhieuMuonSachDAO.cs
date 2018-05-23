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

        public PhieuMuonSach LayPhieuMuonSach(int id)
        {
            QLThuVienDataContext db = new QLThuVienDataContext();
            PhieuMuonSach phieu = db.PhieuMuonSaches.Single(p => p.id == id && p.Disable == false);
            return phieu;
        }

        public void SuaPhieuMuon(PhieuMuonSach phieuMuonSach, List<ChiTietPhieuMuon> dsChiTietPhieuMuonFinal)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                PhieuMuonSach pmsSua = db.PhieuMuonSaches.Single(pms => pms.id == phieuMuonSach.id);
                pmsSua.NgayMuon = phieuMuonSach.NgayMuon;
                pmsSua.HanTra = phieuMuonSach.HanTra;
                pmsSua.NguoiLapPhieu = phieuMuonSach.NguoiLapPhieu;
                pmsSua.NguoiMuon = phieuMuonSach.NguoiMuon;

                foreach(var ctpmUpdate in dsChiTietPhieuMuonFinal)
                {
                    bool timDuoc = false;
                    foreach (var ctpmCurrent in pmsSua.ChiTietPhieuMuons)
                    {                        
                        if(ctpmUpdate.MaSach == ctpmCurrent.MaSach && ctpmUpdate.MaPhieuMuon == ctpmCurrent.MaPhieuMuon)
                        {
                            ctpmCurrent.Sach.SoLuongHienCo += (ctpmCurrent.SoLuong - ctpmUpdate.SoLuong);
                            ctpmCurrent.Sach.SoLuongDaMuon -= (ctpmCurrent.SoLuong - ctpmUpdate.SoLuong);
                            ctpmCurrent.SoLuong = ctpmUpdate.SoLuong;
                            timDuoc = true;
                            break;
                        }
                    }
                    if(!timDuoc)
                    {
                        db.ChiTietPhieuMuons.InsertOnSubmit(ctpmUpdate);
                    }
                }

                foreach(var ctpmCurrent in pmsSua.ChiTietPhieuMuons)
                {
                    bool timDuoc = false;
                    foreach (var ctpmUpdate in dsChiTietPhieuMuonFinal)
                    {
                        if (ctpmUpdate.MaSach == ctpmCurrent.MaSach && ctpmUpdate.MaPhieuMuon == ctpmCurrent.MaPhieuMuon)
                        {
                            timDuoc = true;
                            break;
                        }
                    }
                    if(!timDuoc)
                    {
                        ctpmCurrent.Sach.SoLuongHienCo += ctpmCurrent.SoLuong;
                        ctpmCurrent.Sach.SoLuongDaMuon -= ctpmCurrent.SoLuong;
                        db.ChiTietPhieuMuons.DeleteOnSubmit(ctpmCurrent);
                    }
                }


                db.SubmitChanges();
            }
        }
    }
}