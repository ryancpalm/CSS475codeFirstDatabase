using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using medDatabase.Domain.Models;

namespace medDatabase.Web.Models
{
    public class StayPeriodInputViewModel
    {
        public string IllnessName { get; set; }
        public IEnumerable<SelectListItem> Illnesses { get; set; }

        public StayPeriodInputViewModel()
        {
        }

        public StayPeriodInputViewModel(string illnessName, IEnumerable<Illness> illnesses)
        {
            IllnessName = illnessName;
            InitializeIllnesses(illnesses);
        }

        private void InitializeIllnesses(IEnumerable<Illness> illnesses)
        {
            if (illnesses == null)
            {
                return;
            }

            var illnessesSelectListItems =
                (from illness in illnesses
                 let text = illness.Name
                 select new SelectListItem
                 {
                    Text = text,
                    Value = text
                 })
                 .ToList();
            Illnesses = illnessesSelectListItems;
        }
    }
}