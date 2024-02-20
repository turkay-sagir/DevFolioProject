using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
      

        public ActionResult MessageList()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var value = db.TblContact.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            db.TblContact.Add(p);
            p.IsRead = false;
            p.SendMessageDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MessageList");
        }
    }
}