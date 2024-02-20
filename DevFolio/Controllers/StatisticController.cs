using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.serviceCount = db.TblService.Count();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            ViewBag.lastAddedSocialMedia = db.LastAddedSocialMedia().FirstOrDefault();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.LastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.mostUsedProjectCategory = db.MostUsedProjectCategory().FirstOrDefault();
            return View();
        }
    }
}