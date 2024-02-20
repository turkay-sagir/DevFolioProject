using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class CVDownloadController : Controller
    {
        public ActionResult DownloadCV()
        {
            string filePath = Server.MapPath("~/CV/CV_TurkaySagir.pdf");

            if (System.IO.File.Exists(filePath))
            {
                return File(filePath, "application/pdf", "CV_TurkaySagir.pdf");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}