using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıMvc.Models.EntityFramwork;


namespace OgrencıMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler 
                ;
            
            return View();
                }
        [HttpPost]
        public ActionResult OgrEkle(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p3.TBLKULUPLER.KULUPID).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult sil(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ogrgetir(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
                

            
            return View("ogrgetir",ogr);
        }
        public ActionResult güncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
           // ogr.OGRKULUP = p.OGRKULUP;
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
           ogr.OGRKULUP = klp.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");


        }
    }
}
//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Action", Value = "0" });

//items.Add(new SelectListItem { Text = "Drama", Value = "1" });

//items.Add(new SelectListItem { Text = "Comedy", Value = "2", Selected = true });

//items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

////ViewBag.MovieType = items;