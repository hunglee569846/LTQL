using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using websiteBANHANG.Models;

namespace websiteBANHANG.Controllers
{
    public class ChitietnhapsController : Controller
    {
        private LaptrinhquanlyEntities db = new LaptrinhquanlyEntities();

        // GET: Chitietnhaps
        public ActionResult Index()
        {
            var chitietnhaps = db.Chitietnhaps.Include(c => c.Hanghoa).Include(c => c.Phieunhap);
            return View(chitietnhaps.ToList());
        }

        // GET: Chitietnhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietnhap chitietnhap = db.Chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietnhap);
        }

        // GET: Chitietnhaps/Create
        public ActionResult Create()
        {
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Mahanghoa");
            ViewBag.Maphieunhap = new SelectList(db.Phieunhaps, "Maphieunhap", "Maphieunhap");
            return View();
        }

        // POST: Chitietnhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "STT,Maphieunhap,Mahanghoa,Soluong,Ngaynhap,MaNCC")] Chitietnhap chitietnhap)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Chitietnhaps.Add(chitietnhap);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", chitietnhap.Mahanghoa);
        //    ViewBag.Maphieunhap = new SelectList(db.Phieunhaps, "Maphieunhap", "MaNCC", chitietnhap.Maphieunhap);
        //    return View(chitietnhap);
        //}
        public ActionResult Create([Bind(Include = "STT,Maphieunhap,Mahanghoa,Soluong,Ngaynhap,MaNCC")] Chitietnhap chitietnhap)
        {
            if (ModelState.IsValid)
            {
                db.Chitietnhaps.Add(chitietnhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", chitietnhap.Mahanghoa);
            ViewBag.Maphieunhap = new SelectList(db.Phieunhaps, "Maphieunhap", "MaNCC", chitietnhap.Maphieunhap);
            return View(chitietnhap);
        }
        // GET: Chitietnhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietnhap chitietnhap = db.Chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Mahanghoa", chitietnhap.Mahanghoa);
            ViewBag.Maphieunhap = new SelectList(db.Phieunhaps, "Maphieunhap", "Maphieunhap", chitietnhap.Maphieunhap);
            return View(chitietnhap);
        }

        // POST: Chitietnhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,Maphieunhap,Mahanghoa,Soluong,Ngaynhap,MaNCC")] Chitietnhap chitietnhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietnhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Mahanghoa", chitietnhap.Mahanghoa);
            ViewBag.Maphieunhap = new SelectList(db.Phieunhaps, "Maphieunhap", "Maphieunhap", chitietnhap.Maphieunhap);
            return View(chitietnhap);
        }

        // GET: Chitietnhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietnhap chitietnhap = db.Chitietnhaps.Find(id);
            if (chitietnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietnhap);
        }

        // POST: Chitietnhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietnhap chitietnhap = db.Chitietnhaps.Find(id);
            db.Chitietnhaps.Remove(chitietnhap);
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
