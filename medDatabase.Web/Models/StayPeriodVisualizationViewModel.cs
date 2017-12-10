using System.Collections.Generic;
using medDatabase.Domain.Models;

namespace medDatabase.Web.Models
{
    public class StayPeriodVisualizationViewModel
    {
        public IEnumerable<int> StayPeriodsInDays { get; set; }
        public Illness Illness { get; set; }
    }
}