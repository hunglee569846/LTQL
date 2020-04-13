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
    public class HanghoasController : Controller
    {
        private LaptrinhquanlyEntities db = new LaptrinhquanlyEntities();

        // GET: Hanghoas
        public ActionResult Index()
        {
            var hanghoas = db.Hanghoas.Include(h => h.NhaCC).Include(h => h.NhapXuatTon);
            return View(hanghoas.ToList());
        }

        // GET: Hanghoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // GET: Hanghoas/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC");
            ViewBag.Mahanghoa = new SelectList(db.NhapXuatTons, "Mahanghoa", "Mahanghoa");
            return View();
        }

        // POST: Hanghoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahanghoa,Tenhanghoa,Dongia,Donvitinh,MaNCC")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Hanghoas.Add(hanghoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hanghoa.MaNCC);
            ViewBag.Mahanghoa = new SelectList(db.NhapXuatTons, "Mahanghoa", "Mahanghoa", hanghoa.Mahanghoa);
            return View(hanghoa);
        }

        // GET: Hanghoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hanghoa.MaNCC);
            ViewBag.Mahanghoa = new SelectList(db.NhapXuatTons, "Mahanghoa", "Mahanghoa", hanghoa.Mahanghoa);
            return View(hanghoa);
        }

        // POST: Hanghoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahanghoa,Tenhanghoa,Dongia,Donvitinh,MaNCC")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanghoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hanghoa.MaNCC);
            ViewBag.Mahanghoa = new SelectList(db.NhapXuatTons, "Mahanghoa", "Mahanghoa", hanghoa.Mahanghoa);
            return View(hanghoa);
        }

        // GET: Hanghoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            if (hanghoa == null)
            {
                return HttpNotFound();
            }
            return View(hanghoa);
        }

        // POST: Hanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hanghoa hanghoa = db.Hanghoas.Find(id);
            db.Hanghoas.Remove(hanghoa);
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
