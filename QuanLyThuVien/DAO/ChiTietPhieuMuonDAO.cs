using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietPhieuMuonDAO
    {
        private ChiTietPhieuMuonDAO() { }
        private static ChiTietPhieuMuonDAO instance = null;
        public static ChiTietPhieuMuonDAO Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietPhieuMuonDAO();
                return instance;
            }
        }

        public ChiTietPhieuMuon LayChiTietPhieuMuon(int maPhieuMuon, int maSach)
        {
            var db = new QLThuVienDataContext();
            return db.ChiTietPhieuMuons.Single(ct => ct.MaPhieuMuon == maPhieuMuon && ct.MaSach == maSach);
        }
    }
}
