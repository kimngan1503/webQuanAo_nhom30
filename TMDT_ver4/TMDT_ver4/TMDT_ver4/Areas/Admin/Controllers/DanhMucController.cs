using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace TMDT_ver4.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new DanhMucDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMuc danhmuc)
        {
            if(ModelState.IsValid)
            {
                var dao = new DanhMucDao();
                int id = dao.Insert(danhmuc);
                if(id > 0)
                {
                    return RedirectToAction("Index", "DanhMuc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var danhmuc = new DanhMucDao().ViewDetail(id);
            return View(danhmuc);
        }
        [HttpPost]
        public ActionResult Edit(DanhMuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new DanhMucDao();
                var result = dao.Update(danhmuc);
                if (result)
                {
                    return RedirectToAction("Index", "DanhMuc");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công");
                }
            }
            return View("Index");
        }
    }
}