using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ChiTietPhieuMuonBUS
    {
        private ChiTietPhieuMuonBUS() { }
        private static ChiTietPhieuMuonBUS instance = null;
        public static ChiTietPhieuMuonBUS Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietPhieuMuonBUS();
                return instance;
            }
        }

        public ChiTietPhieuMuon LayChiTietPhieuMuon(int maPhieuMuon, int maSach)
        {
            try
            {
                return ChiTietPhieuMuonDAO.Instance.LayChiTietPhieuMuon(maPhieuMuon, maSach);
            } catch
            {
                return null;
            }
        }

        public int LaySoLuongSachMuon(int maPhieuMuon, int maSach)
        {
            throw new NotImplementedException();
        }

        public bool KiemTraDuSoLuongMuon(int maSach, int maPhieuMuon, int soLuongMoi)
        {
            ChiTietPhieuMuon ctpm = this.LayChiTietPhieuMuon(maPhieuMuon, maSach);
            if (ctpm == null)
            {
                int soLuongSachHienCo = SachBUS.Instance.LaySoLuongSachHienCo(maSach);
                if (soLuongSachHienCo == -1) throw new Exception("Không tìm thấy sách");
                return (soLuongSachHienCo >= soLuongMoi);
            }
            return (soLuongMoi - ctpm.SoLuong <= ctpm.Sach.SoLuongHienCo);
        }
    }
}
