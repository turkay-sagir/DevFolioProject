using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
using PagedList;
using PagedList.Mvc;

namespace DevFolio.Controllers
{
    public class CategoryController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult CategoryList(int page = 1)
        {
            var values = db.TblCategory.ToList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategory p)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory p)
        {
            var value = db.TblCategory.Find(p.CategoryID);
            value.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

    }
}