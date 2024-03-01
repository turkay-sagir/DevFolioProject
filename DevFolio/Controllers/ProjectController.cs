using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ProjectList()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;

            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/devfolio-master/img/"), fileName);
                file.SaveAs(path);

                p.CoverImageUrl = fileName;
            }


            var category = db.TblCategory.Where(x => x.CategoryID == p.TblCategory.CategoryID).FirstOrDefault();
            p.TblCategory = category;
            p.CreatedDate = DateTime.Now;
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryID.ToString()
                                             }).ToList();
            ViewBag.category = category;

            var value=db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p,HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength>0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Templates/devfolio-master/img/"), fileName);
                file.SaveAs(path);

                p.CoverImageUrl = fileName;
            }

            var value = db.TblProject.Find(p.ProjectID);
            value.Title = p.Title;
            value.ProjectCategory = p.TblCategory.CategoryID;
            value.CoverImageUrl = p.CoverImageUrl;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

    }
}