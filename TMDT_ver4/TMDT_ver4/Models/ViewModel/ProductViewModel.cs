using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public int IDsanpham { get; set; }
        public string HinhAnh { get; set; }
        public string TenSanPham { get; set; }
        public decimal? Gia { get; set; }
    }
}
