using OgrenciNotMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OgrenciNotMvc.Controllers
{
    public class KulüpController : Controller
    {

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulüp
        public ActionResult Index()
        {
            var kulup = db.Tbl_Kulüpler.ToList();
            return View(kulup);
        }

        [HttpGet]
        public ActionResult KulupEkle() {
            return View();
        }

        [HttpPost]
        public ActionResult KulupEkle(Tbl_Kulüpler kulup)
        {
            db.Tbl_Kulüpler.Add(kulup);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.Tbl_Kulüpler.Find(id);
            db.Tbl_Kulüpler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulüpGetir(int id)
        {
            var kulup = db.Tbl_Kulüpler.Find(id);

            return View("KulüpGetir",kulup);
        }

        public ActionResult Guncelle(Tbl_Kulüpler p)
        {
            var kulup = db.Tbl_Kulüpler.Find(p.KulüpId);
            kulup.KulüpAd = p.KulüpAd;
            db.SaveChanges();
            return RedirectToAction("Index","Kulüp");
        }
    }
}