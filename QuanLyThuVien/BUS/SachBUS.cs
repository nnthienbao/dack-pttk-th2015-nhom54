using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DTO;
using DAO;
using System.Collections;

namespace BUS
{
    public class SachBUS
    {
        private static string TEN_FOLDER_ANH_BIA = "ANH_BIA";
        private SachBUS() { }
        private static SachBUS instance = null;
        public static SachBUS Instance
        {
            get
            {
                if (instance == null) instance = new SachBUS();
                return instance;
            }
        }

        public void ThemSach(Sach sach, string duongDanAnh)
        {
            sach.DuongDanAnh = CopyFileAnhBia(duongDanAnh);
            SachDAO.Instance.ThemSach(sach);
        }

        private string CopyFileAnhBia(string rawFilePath)
        {
            string newFileName = TaoTenFileAnhBia(rawFilePath);
            string currentPath = Directory.GetCurrentDirectory();
            string targetPath = Path.Combine(currentPath, TEN_FOLDER_ANH_BIA);
            if(!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            string destFile = Path.Combine(targetPath, newFileName);
            File.Copy(rawFilePath, destFile, true);
            return destFile;
        }

        public List<Sach> LayDanhSach()
        {
            return SachDAO.Instance.LayDanhSach();
        }

        private string TaoTenFileAnhBia(string rawFilePath)
        {
            string ext = Path.GetExtension(rawFilePath);
            DateTime now = DateTime.Now;
            return String.Format("BIA_{0}-{1}-{2}_{3}-{4}-{5}{6}", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second, ext);
        }

        public void SuaSach(Sach sach, string duongDanAnhMoi)
        {
            if (string.Compare(sach.DuongDanAnh, duongDanAnhMoi) != 0)
            {
                sach.DuongDanAnh = CopyFileAnhBia(duongDanAnhMoi);
            }
            SachDAO.Instance.SuaSach(sach);
        }
    }
}
