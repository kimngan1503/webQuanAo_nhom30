using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMDT_ver4.Controllers
{
    public class DanhmucController : Controller
    {
        // GET: Danhmuc
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhMuc()
        {
            var model = new DanhMucDao().ListAll();
            return PartialView(model);
        }
    }
}