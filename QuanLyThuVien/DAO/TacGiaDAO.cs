using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TacGiaDAO
    {
        public List<TacGia> LayDanhSach()
        {
            List<TacGia> tacGias;
            using (QLThuVienDataContext db = new QLThuVienDataContext())
            {
                tacGias = db.TacGias.Select(tg => tg).ToList();
            }

            return tacGias;
        }
    }
}
