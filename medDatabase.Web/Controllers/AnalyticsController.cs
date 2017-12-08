using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medDatabase.Web.Controllers
{
    [Authorize]
    public class AnalyticsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Calculates the average stay period for patients with a given condition.
        // Uses joins on medical history, illness, and patient.
        public ActionResult StayPeriod(string illness)
        {
            throw new NotImplementedException();
        }

        // Calculates the average recovery period for patients with a given condition
        // using a given medicaiton. Joins medical history, illness, and patient.
        public ActionResult RecoveryTime(string illness, string medication)
        {
            throw new NotImplementedException();
        }
    }
}