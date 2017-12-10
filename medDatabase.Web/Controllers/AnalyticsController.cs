using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using medDatabase.Domain.Models;
using medDatabase.Web.Contexts;
using medDatabase.Web.Models;

namespace medDatabase.Web.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly MedicalDatabaseContext _dbContext;

        public AnalyticsController()
        {
            _dbContext = new MedicalDatabaseContext();
        }

        public AnalyticsController(MedicalDatabaseContext context)
        {
            _dbContext = context ?? new MedicalDatabaseContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StayPeriod()
        {
            var illnesses = _dbContext.Illnesses;
            var stayPeriodInputViewModel = new StayPeriodInputViewModel(string.Empty, illnesses);
            return View(stayPeriodInputViewModel);
        }

        [HttpPost]
        public ActionResult StayPeriod(StayPeriodInputViewModel stayPeriodInputViewModel)
        {
            var illnessName = stayPeriodInputViewModel.IllnessName;
            return StayPeriodVisualization(illnessName);
        }

        // Calculates the average stay period for patients with a given condition.
        // Uses joins on medical history, illnessName, and patient.
        public ActionResult StayPeriodVisualization(string illnessName)
        {
            if (!IllnessExists(illnessName))
            {
                return View("InvalidIllness");
            }
            var illness = GetIllness(illnessName);
            var illnessId = illness.Id;
            var patientsWithIllness = GetPatientsWithIllness(illnessId);
            var stayPeriods = CalculateStayPeriods(patientsWithIllness);
            var stayPeriodViewModel = new StayPeriodVisualizationViewModel
            {
                Illness = illness,
                StayPeriodsInDays = stayPeriods
            };
            return View("StayPeriodVisualization", stayPeriodViewModel);
        }

        private static IEnumerable<int> CalculateStayPeriods(IEnumerable<Patient> patients)
        {
            var stayPeriodsInDays = (from patient in patients
                                     where patient.DischargeDate != null
                                     select patient.DischargeDate - patient.AdmissionDate into stayPeriod
                                     select stayPeriod.Value.Days).ToList();
            return stayPeriodsInDays;
        }

        private IEnumerable<Patient> GetPatientsWithIllness(int illnessId)
        {
            var patientsWithIllness = (from medicalHistory in _dbContext.MedicalHistories
                                       where medicalHistory.IllnessId == illnessId
                                       select medicalHistory.PatientId into patientId
                                       select _dbContext.Patients.FirstOrDefault(p => p.Id == patientId))
                                       .ToList();
            return patientsWithIllness;
        }

        private Illness GetIllness(string illnessName)
        {
            var illness = _dbContext.Illnesses.First(i => i.Name == illnessName);
            return illness;
        }

        private bool IllnessExists(string illnessName)
        {
            var illnessExists = _dbContext.Illnesses.Any(i => i.Name == illnessName);
            return illnessExists;
        }
    }
}