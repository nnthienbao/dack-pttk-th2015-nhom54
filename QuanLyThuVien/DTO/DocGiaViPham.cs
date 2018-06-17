using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class DocGiaViPham
    {
        private string maDocGia;
        private string tenDocGia;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private int soLanViPham;

        public string MaDocGia
        {
            get
            {
                return maDocGia;
            }

            set
            {
                maDocGia = value;
            }
        }

        public string TenDocGia
        {
            get
            {
                return tenDocGia;
            }

            set
            {
                tenDocGia = value;
            }
        }

        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public int SoLanViPham
        {
            get
            {
                return soLanViPham;
            }

            set
            {
                soLanViPham = value;
            }
        }

        public DocGiaViPham(string maDocGia, string tenDocGia, bool gioiTinh, DateTime ngaySinh, int soLanViPham)
        {
            this.MaDocGia = maDocGia;
            this.TenDocGia = tenDocGia;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.SoLanViPham = soLanViPham;
        }
    }
}
