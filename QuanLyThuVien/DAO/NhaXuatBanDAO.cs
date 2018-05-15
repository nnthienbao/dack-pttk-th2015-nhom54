using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhaXuatBanDAO
    {
        private NhaXuatBanDAO() { }
        private static NhaXuatBanDAO instance = null;
        public static NhaXuatBanDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhaXuatBanDAO();
                return instance;
            }
        }

        public List<NhaXuatBan> LayDanhSach()
        {
            List<NhaXuatBan> nxbs = null;
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                nxbs = db.NhaXuatBans.Select(nxb => nxb).Where(nxb => nxb.Disable == false).ToList();
            }
            return nxbs;
        }

        public void ThemNhaXuatBan(string tenNXB)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                NhaXuatBan nxbMoi = new NhaXuatBan
                {
                    Ten = tenNXB
                };
                db.NhaXuatBans.InsertOnSubmit(nxbMoi);
                db.SubmitChanges();
            }
        }

        public void XoaNhaXuatBan(string pid)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                NhaXuatBan nxbXoa = db.NhaXuatBans.Single(nxb => nxb.pid == pid);
                nxbXoa.Disable = true;
                db.SubmitChanges();
            }
        }

        public void SuaNhaXuatBan(NhaXuatBan nhaXuatBan)
        {
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                NhaXuatBan nxbSua = db.NhaXuatBans.Single(nxb => nxb.pid == nhaXuatBan.pid);
                nxbSua.Ten = nhaXuatBan.Ten;
                db.SubmitChanges();
            }
        }
    }
}
