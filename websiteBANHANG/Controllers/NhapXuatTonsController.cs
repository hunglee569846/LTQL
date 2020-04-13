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
    public class NhapXuatTonsController : Controller
    {
        private LaptrinhquanlyEntities db = new LaptrinhquanlyEntities();

        // GET: NhapXuatTons
        public ActionResult Index()
        {
            var nhapXuatTons = db.NhapXuatTons.Include(n => n.Hanghoa);
            return View(nhapXuatTons.ToList());
        }

        // GET: NhapXuatTons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            return View(nhapXuatTon);
        }

        // GET: NhapXuatTons/Create
        public ActionResult Create()
        {
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa");
            return View();
        }

        // POST: NhapXuatTons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahanghoa,STT,SoNhap,SoXuat,SoTon")] NhapXuatTon nhapXuatTon)
        {
            if (ModelState.IsValid)
            {
                db.NhapXuatTons.Add(nhapXuatTon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", nhapXuatTon.Mahanghoa);
            return View(nhapXuatTon);
        }

        // GET: NhapXuatTons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", nhapXuatTon.Mahanghoa);
            return View(nhapXuatTon);
        }

        // POST: NhapXuatTons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahanghoa,STT,SoNhap,SoXuat,SoTon")] NhapXuatTon nhapXuatTon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhapXuatTon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mahanghoa = new SelectList(db.Hanghoas, "Mahanghoa", "Tenhanghoa", nhapXuatTon.Mahanghoa);
            return View(nhapXuatTon);
        }

        // GET: NhapXuatTons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            if (nhapXuatTon == null)
            {
                return HttpNotFound();
            }
            return View(nhapXuatTon);
        }

        // POST: NhapXuatTons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhapXuatTon nhapXuatTon = db.NhapXuatTons.Find(id);
            db.NhapXuatTons.Remove(nhapXuatTon);
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
