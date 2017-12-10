using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using medDatabase.Domain.Models;
using medDatabase.Web.Contexts;

namespace medDatabase.Web.Controllers
{
    public class NurseSpecialtiesController : Controller
    {
        private MedicalDatabaseContext db = new MedicalDatabaseContext();

        // GET: NurseSpecialties
        public ActionResult Index()
        {
            return View(db.NurseSpecialties.ToList());
        }

        // GET: NurseSpecialties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseSpecialty nurseSpecialty = db.NurseSpecialties.Find(id);
            if (nurseSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(nurseSpecialty);
        }

        // GET: NurseSpecialties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NurseSpecialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] NurseSpecialty nurseSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.NurseSpecialties.Add(nurseSpecialty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurseSpecialty);
        }

        // GET: NurseSpecialties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseSpecialty nurseSpecialty = db.NurseSpecialties.Find(id);
            if (nurseSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(nurseSpecialty);
        }

        // POST: NurseSpecialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] NurseSpecialty nurseSpecialty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurseSpecialty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurseSpecialty);
        }

        // GET: NurseSpecialties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseSpecialty nurseSpecialty = db.NurseSpecialties.Find(id);
            if (nurseSpecialty == null)
            {
                return HttpNotFound();
            }
            return View(nurseSpecialty);
        }

        // POST: NurseSpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NurseSpecialty nurseSpecialty = db.NurseSpecialties.Find(id);
            db.NurseSpecialties.Remove(nurseSpecialty);
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
