using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMDT_ver4.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Detail(int id)
        {
            var sanpham = new SanPhamDao().ViewDetail(id);
            ViewBag.DanhMuc = new DanhMucDao().ViewDetail(sanpham.IDdanhmuc.Value);
            ViewBag.Splienquan = new SanPhamDao().ListSanPhamLienQuan(id);
            return View(sanpham);
        }

        public ActionResult LoaiSP(int id)
        {
            //var dm = new DanhMucDao().ViewDetail(id);            
            //ViewBag.Category = dm;

            var loai = new LoaiDao().ViewDetail(id);
            ViewBag.Loai = loai;

            var model = new SanPhamDao().ListSanPhamCungLoai(id);
            return View(model);

            //var category  = new LoaiDao().ViewDetail(id);
            //return View(category);
        }

        public JsonResult ListName(string q)
        {
            var data = new SanPhamDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet) ;
        }

        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var mode = new SanPhamDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Previous = page - 1;

            return View(mode);
        }
    }
}