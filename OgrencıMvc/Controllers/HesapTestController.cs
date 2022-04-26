using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrencıMvc.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(double sayi1=0,double sayi2=0)
        {
            double toplam = sayi1+sayi2;
            double cıkarma = sayi1-sayi2;
            double bolme = sayi1 / sayi2;
            double carpma = sayi1*sayi2;

            ViewBag.tpl = toplam;
            ViewBag.ckr = cıkarma;
            ViewBag.blm = bolme;
            ViewBag.crp = carpma;
            ViewBag.sayi1 = sayi1;
            ViewBag.sayi2 = sayi2;
            return View();
        }

    }
}