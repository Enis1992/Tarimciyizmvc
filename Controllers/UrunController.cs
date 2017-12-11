using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tarimciyiz.Models;
using System.IO;
using tarimciyiz.App_Class;


namespace tarimciyiz.Controllers
{
    public class UrunController : Controller
    {
        private ModelTarimciyiz db = new ModelTarimciyiz();

        // GET: Urun
        public ActionResult Index()
        {
            var urun = db.Urun.Include(u => u.Kategori).Include(u => u.Marka);
            return View(urun.ToList());
        }

        // GET: Urun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Urun/Create
        public ActionResult Create()
        {
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi");
            ViewBag.markaID = new SelectList(db.Marka, "markaID", "markaAdi");
            return View();
        }

        // POST: Urun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "urunID,kategoriID,markaID,urunAdi,urunAciklama,urunFiyat")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.markaID = new SelectList(db.Marka, "markaID", "markaAdi", urun.markaID);
            return View(urun);
        }

        // GET: Urun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.markaID = new SelectList(db.Marka, "markaID", "markaAdi", urun.markaID);
            return View(urun);
        }

        // POST: Urun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "urunID,kategoriID,markaID,urunAdi,urunAciklama,urunFiyat")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.markaID = new SelectList(db.Marka, "markaID", "markaAdi", urun.markaID);
            return View(urun);
        }

        // GET: Urun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Urun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var resimler = db.Resim.Where(x => x.urunID == id).ToList();
            foreach (var resim in resimler)
            {
                var yol = Server.MapPath("~/Resimler/" + resim.resimAdi);
                System.IO.File.Delete(yol);
            }


            Urun urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ResimEkle(int id)
        {
            Urun urun = db.Urun.Find(id);
            return View(urun);

        }


        [HttpPost]
        public ActionResult ResimEkle(Resimler resim, int urunid)
        {

            foreach (var dosya in resim.Dosyalar)
            {
                if (dosya.ContentLength > 0)
                {
                    //REsimler klasörüne resimleri ekliyoruz..
                    var dosyaAdi = Guid.NewGuid() + Path.GetExtension(dosya.FileName);
                    var adres = Path.Combine(Server.MapPath("~/Resimler"), dosyaAdi);
                    dosya.SaveAs(adres);


                    // veri tabanına kaydediyoruz..

                    Resim rsm = new Resim();
                    rsm.urunID = urunid;
                   rsm.resimAdi = dosyaAdi;
                    db.Resim.Add(rsm);

                }
                else
                {
                    ViewBag.Mesaj = "yükleme işlemi yapılamadı";
                    return View();
                }
               

            }
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
