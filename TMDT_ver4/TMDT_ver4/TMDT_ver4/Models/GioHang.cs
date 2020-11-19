using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT_ver4.Models
{
    [Serializable]
    public class GioHang
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string Gia { get; set; }
        public int Soluong { get; set; }
        public int ThanhTien
        {
            get { return Soluong * Int32.Parse(Gia); }
        }
    }
}