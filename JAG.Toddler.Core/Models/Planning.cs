using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAG.Toddler.Core.Models.Default;
using Microsoft.EntityFrameworkCore;

namespace JAG.Toddler.Core.Models
{
    public class Planning
    {
        public Planning(JAGToddlerDatabaseContext context)
        {
            PlanDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        }

        public Planning(JAGToddlerDatabaseContext context, DateTime planDate, int storeId, int classId)
        {
            PlanDate = new DateTime(planDate.Year, planDate.Month, 1, 0, 0, 0);

            SelectedStoreId = storeId;
            SelectedClassId = classId;
        }

        public DateTime PlanDate { get; set; }

        public int? SelectedStoreId { get; set; }
        public int? SelectedClassId { get; set; }

        public IEnumerable<LogEntries> TwoPriorYear { get; set; }
        public IEnumerable<LogEntries> PriorYear { get; set; }
        public IEnumerable<LogEntries> CurrentYear { get; set; }
        public IEnumerable<LogEntries> NextYear { get; set; }
    }
}
