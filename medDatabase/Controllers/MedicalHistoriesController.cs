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
    public class MedicalHistoriesController : Controller
    {
        private Medical_DatabaseEntities db = new Medical_DatabaseEntities();

        // GET: MedicalHistories
        public ActionResult Index()
        {
            var medicalHistories = db.MedicalHistories.Include(m => m.Illness).Include(m => m.Patient);
            return View(medicalHistories.ToList());
        }

        // GET: MedicalHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistories.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Create
        public ActionResult Create()
        {
            ViewBag.IllnessId = new SelectList(db.Illnesses, "Id", "Name");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn");
            return View();
        }

        // POST: MedicalHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,IllnessId,DiagnosisDate,LastVisitDate")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.MedicalHistories.Add(medicalHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IllnessId = new SelectList(db.Illnesses, "Id", "Name", medicalHistory.IllnessId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", medicalHistory.PatientId);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistories.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.IllnessId = new SelectList(db.Illnesses, "Id", "Name", medicalHistory.IllnessId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", medicalHistory.PatientId);
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,IllnessId,DiagnosisDate,LastVisitDate")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IllnessId = new SelectList(db.Illnesses, "Id", "Name", medicalHistory.IllnessId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "Ssn", medicalHistory.PatientId);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistories.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalHistory medicalHistory = db.MedicalHistories.Find(id);
            db.MedicalHistories.Remove(medicalHistory);
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
