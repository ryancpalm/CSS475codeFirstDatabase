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
    public class PrescriptionsController : Controller
    {
        private Medical_DatabaseEntities db = new Medical_DatabaseEntities();

        // GET: Prescriptions
        public ActionResult Index()
        {
            var prescriptions = db.Prescriptions.Include(p => p.Employee).Include(p => p.Medication).Include(p => p.Patient);
            return View(prescriptions.ToList());
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Employees, "Id", "Ssn");
            ViewBag.MedicationId = new SelectList(db.Medications, "Id", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,DoctorId,MedicationId,Id,Refills,Quantity,StartDate,EndDate")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Employees, "Id", "Ssn", prescription.DoctorId);
            ViewBag.MedicationId = new SelectList(db.Medications, "Id", "Name", prescription.MedicationId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", prescription.PatientId);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Employees, "Id", "Ssn", prescription.DoctorId);
            ViewBag.MedicationId = new SelectList(db.Medications, "Id", "Name", prescription.MedicationId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", prescription.PatientId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,DoctorId,MedicationId,Id,Refills,Quantity,StartDate,EndDate")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Employees, "Id", "Ssn", prescription.DoctorId);
            ViewBag.MedicationId = new SelectList(db.Medications, "Id", "Name", prescription.MedicationId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", prescription.PatientId);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
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
