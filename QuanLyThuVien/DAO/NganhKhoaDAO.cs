using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NganhKhoaDAO
    {
        public List<NganhKhoa> LayDanhSach()
        {
            List<NganhKhoa> nganhKhoas = new List<NganhKhoa>();
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                nganhKhoas = db.NganhKhoas.Select(nk => nk).ToList();
            }

            return nganhKhoas;
        }
    }
}
