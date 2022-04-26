using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıMvc.Models.EntityFramwork;
using OgrencıMvc.Models;

namespace OgrencıMvc.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var not = db.TBLNOTLAR.ToList();
            return View(not);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p4)
        {
            db.TBLNOTLAR.Add(p4);
            db.SaveChanges();
            return View();
        }
        public ActionResult notgetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("notgetir", not);
        }
        [HttpPost]
        public ActionResult notgetir(Class1 model,TBLNOTLAR p, int SINAV1 = 0, int SINAV2=0, int SINAV3=0, int PROJE=0)
        {
            if (model.islem == "HESAPLA")
            {
                //işlem 1;
                int ortalama = (SINAV1+SINAV2+SINAV3+PROJE)/4 ;
                ViewBag.ort = ortalama;
                if (ortalama >= 50)
                {
                    ViewBag.drm = "True";
                }
                else
                {
                    ViewBag.drm = "False";
                }
            }
            if (model.islem == "NOTGÜNCELLE")
            {
                //İŞLEM2
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                snv.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index", "Not");

            }
            return View();
        }


    }

}