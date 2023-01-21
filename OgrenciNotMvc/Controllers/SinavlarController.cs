using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar=db.Tbl_Notlar.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(Tbl_Notlar not)
        {
            db.Tbl_Notlar.Add(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.Tbl_Notlar.Find(id);
            return View("NotGetir", not);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model,Tbl_Notlar p,int sinav1=0,int sinav2=0,int sinav3 = 0,int proje = 0) {

            if (model.islem =="HESAPLA")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;

                if(ortalama >= 50)
                {
                    p.Durum = true;
                }
                else
                {
                    p.Durum = false;
                }
                ViewBag.ort = ortalama;
                ViewBag.durum = p.Durum;

            }
            if (model.islem=="NOTGUNCELLE")
            {
                var not = db.Tbl_Notlar.Find(p.NotId);
                not.Sinav1 = p.Sinav1;
                not.Sinav2 = p.Sinav2;
                not.Sinav3 = p.Sinav3;
                not.Proje = p.Proje;
                not.Ortalama = p.Ortalama;
                not.Durum = p.Durum;
                db.SaveChanges();
                return RedirectToAction("Index", "Sinavlar");
            }
            return View();
        }
    }
}