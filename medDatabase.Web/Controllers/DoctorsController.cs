using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using medDatabase.Domain.Models;
using medDatabase.Web.Contexts;

namespace medDatabase.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private MedicalDatabaseContext db = new MedicalDatabaseContext();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.DoctorSpecialty).Include(d => d.Employee);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Name");
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,DoctorSpecialtyId,Employee_Id")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Name", doctor.DoctorSpecialtyId);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", doctor.EmployeeId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Name", doctor.DoctorSpecialtyId);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", doctor.EmployeeId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,DoctorSpecialtyId,Employee_Id")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorSpecialtyId = new SelectList(db.DoctorSpecialties, "Id", "Name", doctor.DoctorSpecialtyId);
            ViewBag.Employee_Id = new SelectList(db.Employees, "Id", "Ssn", doctor.EmployeeId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
