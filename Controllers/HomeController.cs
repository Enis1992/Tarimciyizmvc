using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tarimciyiz.Models;

namespace tarimciyiz.Controllers
{
    public class HomeController : Controller
    {
        ModelTarimciyiz db = new ModelTarimciyiz();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult miniSepet()
        {
            return PartialView();
        }
        public PartialViewResult Kategoriler()
        {
            
            return PartialView(db.Kategori.ToList());
        }
        public PartialViewResult KategoriListesi()
        {
            return PartialView(db.Kategori.ToList());
        }
        public PartialViewResult OnikiUrun()
        {
            return PartialView(db.Urun.Take(12).ToList());
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public ActionResult Urunler(int id)
        {
            return View(db.Urun.Where(x=>x.kategoriID==id)); 
        }
        public ActionResult UrunDetayı(int id)
        {
            ViewBag.Resimler = db.Resim.Where(x => x.urunID == id);
            return View(db.Urun.Find(id));
        }
    }
}