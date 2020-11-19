using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using Models.ViewModel;

namespace Models.DAO
{
    public class SanPhamDao
    {
        Model1 db = null;
        public SanPhamDao()
        {
            db = new Model1();
        }
        public List<SanPham> ListSanPhamMoi(int top)
        {
            return db.SanPhams.OrderByDescending(x => x.TenSanPham).Take(top).ToList();
        }

        public List<SanPham> ListSanPhamGiam (int sale)
        {
            return db.SanPhams.OrderByDescending(x => x.GiamGia).Take(sale).ToList();
        }

        public List<SanPham> ListSanPhamLienQuan(int sanphamId)
        {
            var sp = db.SanPhams.Find(sanphamId);
            return db.SanPhams.Where(x => x.IDsanpham != sanphamId && x.IDdanhmuc == sp.IDdanhmuc).ToList();
        }

        public List<SanPham> ListSanPhamCungLoai(int loaiId)
        {
            //var sp = db.SanPhams.Find(sanphamId);
            return db.SanPhams.Where(x =>x.IDloai == loaiId).ToList();
            //return db.SanPhams.OrderByDescending(x => x.IDloai == sanphamId).ToList();
        }
        public SanPham ViewDetail(int id)
        {
            return db.SanPhams.Find(id);
        }

        public List<string>ListName(string keyword)
        {
            return db.SanPhams.Where(x => x.TenSanPham.Contains(keyword)).Select(x => x.TenSanPham).ToList();
        }

        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            totalRecord = db.SanPhams.Where(x => x.TenSanPham.Contains(keyword)).Count();
            var model = from a in db.SanPhams
                        join b in db.Loais
                        on a.IDdanhmuc equals b.IDdanhmuc
                        where a.TenSanPham.Contains(keyword)
                        select new ProductViewModel()
                        {
                            IDsanpham = a.IDsanpham,
                            TenSanPham = a.TenSanPham,
                            HinhAnh = a.HinhAnh,
                            Gia = a.Gia
                        };
            model.OrderByDescending(x => x.Gia).Skip((pageIndex - 1)* pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
