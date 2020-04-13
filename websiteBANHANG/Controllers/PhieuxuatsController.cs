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
    public class PhieuxuatsController : Controller
    {
        private LaptrinhquanlyEntities db = new LaptrinhquanlyEntities();

        // GET: Phieuxuats
        public ActionResult Index()
        {
            var phieuxuats = db.Phieuxuats.Include(p => p.Khachhang);
            return View(phieuxuats.ToList());
        }

        // GET: Phieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // GET: Phieuxuats/Create
        public ActionResult Create()
        {
            ViewBag.Makhachhang = new SelectList(db.Khachhangs, "Makhachhang", "Tenkhachhang");
            return View();
        }

        // POST: Phieuxuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphieuxuat,Ngaytao,Makhachhang")] Phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Phieuxuats.Add(phieuxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makhachhang = new SelectList(db.Khachhangs, "Makhachhang", "Tenkhachhang", phieuxuat.Makhachhang);
            return View(phieuxuat);
        }

        // GET: Phieuxuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makhachhang = new SelectList(db.Khachhangs, "Makhachhang", "Tenkhachhang", phieuxuat.Makhachhang);
            return View(phieuxuat);
        }

        // POST: Phieuxuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphieuxuat,Ngaytao,Makhachhang")] Phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makhachhang = new SelectList(db.Khachhangs, "Makhachhang", "Tenkhachhang", phieuxuat.Makhachhang);
            return View(phieuxuat);
        }

        // GET: Phieuxuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // POST: Phieuxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            db.Phieuxuats.Remove(phieuxuat);
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
