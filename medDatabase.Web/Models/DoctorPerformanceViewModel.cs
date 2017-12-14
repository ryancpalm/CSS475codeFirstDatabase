using System.Collections.Generic;
using medDatabase.Domain.Models;

namespace medDatabase.Web.Models
{
    public class DoctorPerformanceViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<int> PatientStayPeriods { get; set; }
    }
}