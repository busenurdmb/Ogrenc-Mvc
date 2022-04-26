using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıMvc.Models.EntityFramwork;

namespace OgrencıMvc.Controllers
{
    public class kuluplerController : Controller
    {
        // GET: kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulüp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulüp(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulüpGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("KulüpGetir",kulup);
        }
        public ActionResult güncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "kulupler");
        }
    }
}