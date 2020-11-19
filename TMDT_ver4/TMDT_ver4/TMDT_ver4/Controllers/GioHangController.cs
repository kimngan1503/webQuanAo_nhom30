using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMDT_ver4.Models;

namespace TMDT_ver4.Controllers
{
    public class GioHangController : Controller
    {
        //private const string CartSession = "CartSession";
        // GET: GioHang
        Model1 db = new Model1();
        public ActionResult Index()
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            return View(giohang);
            //var cart = Session[CartSession];
            //var list = new List<GioHang>();
            //if(cart!= null)
            //{
            //    list = (List<GioHang>)cart;
            //}
            //return View(list);
        }

        //Xử lý nút thêm vào giỏ hàng
        public ActionResult ThemSP(int sanPhamID)
        {
            if(Session["giohang"] == null)
            {
                Session["giohang"] = new List<GioHang>();
            }

            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            if(giohang.FirstOrDefault(x => x.SanPhamID == sanPhamID) == null)
            {
                SanPham sp = db.SanPhams.Find(sanPhamID);

                GioHang newItem = new GioHang()
                {
                    SanPhamID = sanPhamID,
                    TenSanPham = sp.TenSanPham,
                    Soluong = 1,
                    HinhAnh = sp.HinhAnh,
                    Gia = sp.Gia.ToString()
                };

                giohang.Add(newItem);
            }
            else // Sản phẩm đã có khách chọn thì thêm số lượng lên
            {
                GioHang cardItem = giohang.FirstOrDefault(x => x.SanPhamID == sanPhamID);
                cardItem.Soluong++;
            }
            return Redirect(Request.UrlReferrer.ToString());
            //var sp = new SanPhamDao().ViewDetail(spID);
            //var cart = Session[CartSession];
            //if (cart != null)
            //{
            //    var list = (List<GioHang>)cart;
            //    if (list.Exists(x => x.SanPham.IDsanpham == spID))
            //    {
            //        foreach (var item in list)
            //        {
            //            if (item.SanPham.IDsanpham == spID)
            //            {
            //                item.Soluong += sl;
            //            }
            //        }
            //    }

            //    else
            //    {
            //        var item = new GioHang();
            //        item.SanPham = sp;
            //        item.Soluong = sl;                    
            //        list.Add(item);                    
            //    }
            //    //gán vào session
            //    Session[CartSession] = list;
            //}
            //else
            //{
            //    //tạo mới giỏ hàng
            //    var item = new GioHang();
            //    item.SanPham = sp;
            //    item.Soluong = sl;
            //    var list = new List<GioHang>();
            //    list.Add(item);

            //    //gán vào session
            //    Session[CartSession] = list;
            //}
            //return RedirectToAction("Index");
        }
    }
}