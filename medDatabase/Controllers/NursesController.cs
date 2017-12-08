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
    public class NursesController : Controller
    {
        private Medical_DatabaseEntities db = new Medical_DatabaseEntities();

        // GET: Nurses
        public ActionResult Index()
        {
            var nurses = db.Nurses.Include(n => n.Employee).Include(n => n.NurseSpecialty);
            return View(nurses.ToList());
        }

        // GET: Nurses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // GET: Nurses/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn");
            ViewBag.NurseSpecialtyId = new SelectList(db.NurseSpecialties, "Id", "Name");
            return View();
        }

        // POST: Nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,NurseSpecialtyId,Employee_Id")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Nurses.Add(nurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", nurse.Employee_Id);
            ViewBag.NurseSpecialtyId = new SelectList(db.NurseSpecialties, "Id", "Name", nurse.NurseSpecialtyId);
            return View(nurse);
        }

        // GET: Nurses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", nurse.Employee_Id);
            ViewBag.NurseSpecialtyId = new SelectList(db.NurseSpecialties, "Id", "Name", nurse.NurseSpecialtyId);
            return View(nurse);
        }

        // POST: Nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,NurseSpecialtyId,Employee_Id")] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", nurse.Employee_Id);
            ViewBag.NurseSpecialtyId = new SelectList(db.NurseSpecialties, "Id", "Name", nurse.NurseSpecialtyId);
            return View(nurse);
        }

        // GET: Nurses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nurse nurse = db.Nurses.Find(id);
            if (nurse == null)
            {
                return HttpNotFound();
            }
            return View(nurse);
        }

        // POST: Nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nurse nurse = db.Nurses.Find(id);
            db.Nurses.Remove(nurse);
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
