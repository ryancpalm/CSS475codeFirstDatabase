using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medDatabase.Models;

namespace medDatabase.Controllers
{
    public class DoctorSpecialtiesController : Controller
    {
        private Medical_DatabaseEntities db = new Medical_DatabaseEntities();

        // GET: DoctorSpecialties
        public ActionResult Index()
        {
            return View(db.DoctorSpecialties.ToList());
        }

        // GET: DoctorSpecialties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialty doctorSpecialty = db.DoctorSpecialties.Find(id);
            if (doctorSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorSpecialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DoctorSpecialty doctorSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.DoctorSpecialties.Add(doctorSpecialty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialty doctorSpecialty = db.DoctorSpecialties.Find(id);
            if (doctorSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialty);
        }

        // POST: DoctorSpecialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DoctorSpecialty doctorSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorSpecialty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorSpecialty);
        }

        // GET: DoctorSpecialties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorSpecialty doctorSpecialty = db.DoctorSpecialties.Find(id);
            if (doctorSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(doctorSpecialty);
        }

        // POST: DoctorSpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorSpecialty doctorSpecialty = db.DoctorSpecialties.Find(id);
            db.DoctorSpecialties.Remove(doctorSpecialty);
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
