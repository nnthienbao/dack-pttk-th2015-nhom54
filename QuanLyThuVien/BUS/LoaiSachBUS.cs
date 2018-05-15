﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class LoaiSachBUS
    {
        private LoaiSachBUS() { }
        private static LoaiSachBUS instance = null;
        public static LoaiSachBUS Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LoaiSachBUS();
                }
                return instance;
            }
        }

        public void ThemLoaiSach(string ten)
        {
            LoaiSachDAO.Instance.ThemNganhKhoa(ten);
        }

        public List<LoaiSach> LayDanhSach()
        {
            return LoaiSachDAO.Instance.LayDanhSach();
        }

        public void SuaLoaiSach(LoaiSach loaiSach)
        {
            LoaiSachDAO.Instance.SuaLoaiSach(loaiSach);
        }

        public void XoaLoaiSach(string pid)
        {
            LoaiSachDAO.Instance.XoaLoaiSach(pid);
        }
    }
}
