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
    public class ChitietxuatsController : Controller
    {
        private LaptrinhquanlyEntities db = new LaptrinhquanlyEntities();

        // GET: Chitietxuats
        public ActionResult Index()
        {
            var chitietxuats = db.Chitietxuats.Include(c => c.Hanghoa).Include(c => c.Phieuxuat);
            return View(chitietxuats.ToList());
        }

        // GET: Chitietxuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietxuat chitietxuat = db.Chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietxuat);
        }

        // GET: Chitietxuats/Create
        public ActionResult Create()
        {
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa");
            ViewBag.Maphieuxuat = new SelectList(db.Phieuxuats, "Maphieuxuat", "Makhachhang");
            return View();
        }

        // POST: Chitietxuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STT,Maphieuxuat,Mahanghoa,soluong,Ngayxuat,Makhachhang")] Chitietxuat chitietxuat)
        {
            if (ModelState.IsValid)
            {
                db.Chitietxuats.Add(chitietxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", chitietxuat.Mahanghoa);
            ViewBag.Maphieuxuat = new SelectList(db.Phieuxuats, "Maphieuxuat", "Makhachhang", chitietxuat.Maphieuxuat);
            return View(chitietxuat);
        }

        // GET: Chitietxuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietxuat chitietxuat = db.Chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", chitietxuat.Mahanghoa);
            ViewBag.Maphieuxuat = new SelectList(db.Phieuxuats, "Maphieuxuat", "Makhachhang", chitietxuat.Maphieuxuat);
            return View(chitietxuat);
        }

        // POST: Chitietxuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STT,Maphieuxuat,Mahanghoa,soluong,Ngayxuat,Makhachhang")] Chitietxuat chitietxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", chitietxuat.Mahanghoa);
            ViewBag.Maphieuxuat = new SelectList(db.Phieuxuats, "Maphieuxuat", "Makhachhang", chitietxuat.Maphieuxuat);
            return View(chitietxuat);
        }

        // GET: Chitietxuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietxuat chitietxuat = db.Chitietxuats.Find(id);
            if (chitietxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietxuat);
        }

        // POST: Chitietxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietxuat chitietxuat = db.Chitietxuats.Find(id);
            db.Chitietxuats.Remove(chitietxuat);
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
