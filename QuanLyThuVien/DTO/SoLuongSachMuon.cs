using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class SoLuongSachMuon
    {
        private string maSach;
        private string tenSach;
        private int soLuong;

        public SoLuongSachMuon() { }
        public SoLuongSachMuon(string maSach, string tenSach, int soLuong)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.SoLuong = soLuong;
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public string MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }
    }
}
