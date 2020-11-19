using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace TMDT_ver4.Areas.Admin.Controllers
{
    public class LoaiController : Controller
    {
        // GET: Admin/Loai
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new LoaiDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Loai loai)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiDao();
                int id = dao.Insert(loai);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Loai");
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
            var loai = new LoaiDao().ViewDetail(id);
            return View(loai);
        }
        [HttpPost]
        public ActionResult Edit(Loai loai)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiDao();
                var result = dao.Update(loai);
                if (result)
                {
                    return RedirectToAction("Index", "Loai");
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