using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.Tbl_Ogrenciler.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciKayit()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kulüpler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulüpAd,
                                                 Value = i.KulüpId.ToString()
                                             }).ToList();

            ViewBag.Degerler = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciKayit(Tbl_Ogrenciler ogr)
        {
            var club = db.Tbl_Kulüpler.Where(m => m.KulüpId == ogr.Tbl_Kulüpler.KulüpId).FirstOrDefault();
            ogr.Tbl_Kulüpler = club;
            db.Tbl_Ogrenciler.Add(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.Tbl_Ogrenciler.Find(id);
            db.Tbl_Ogrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.Tbl_Ogrenciler.Find(id);

            return View("OgrenciGetir", ogr);
        }

        [HttpPost]
        public ActionResult Guncelle(Tbl_Ogrenciler p)
        {
            var ogr = db.Tbl_Ogrenciler.Find(p.OgrenciId);
            ogr.OgrAd = p.OgrAd;
            ogr.OgrSoyad= p.OgrSoyad;
            ogr.OgrFotograf = p.OgrFotograf;
            ogr.OgrCinsiyet = p.OgrCinsiyet;
            ogr.OgrKulüp = p.OgrKulüp;
            
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");

        }
    }
}

//List<SelectListItem> items = new List<SelectListItem>();

//items.Add(new SelectListItem { Text = "Action", Value = "0" });

//items.Add(new SelectListItem { Text = "Drama", Value = "1" });

//items.Add(new SelectListItem { Text = "Comedy", Value = "2" });

//items.Add(new SelectListItem { Text = "Science Fiction", Value = "3" });

//ViewBag.MovieType = items;