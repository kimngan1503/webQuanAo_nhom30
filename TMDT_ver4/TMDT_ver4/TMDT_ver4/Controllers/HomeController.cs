using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMDT_ver4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var sanphamDao = new SanPhamDao();
            ViewBag.SanPhamMoi = sanphamDao.ListSanPhamMoi(5);
            ViewBag.SanPhamGiam = sanphamDao.ListSanPhamGiam(5);
            return View();
        }
    }
}