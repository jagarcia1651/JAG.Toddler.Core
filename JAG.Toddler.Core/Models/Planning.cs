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

            StoreId = 0;
            ClassId = 0;

            TwoPriorYear = Enumerable.Empty<LogEntries>();
            PriorYear = Enumerable.Empty<LogEntries>();
            CurrentYear = Enumerable.Empty<LogEntries>();
            NextYear = Enumerable.Empty<LogEntries>();
        }

        public Planning(JAGToddlerDatabaseContext context, DateTime planDate, int storeId, int classId)
        {
            PlanDate = new DateTime(planDate.Year, planDate.Month, 1, 0, 0, 0);

            StoreId = storeId;
            ClassId = classId;

            TwoPriorYear = context.LogEntries
                .Where(l => l.ClassId == ClassId)
                .Where(l => l.StoreId == StoreId)
                .Where(l => l.LogDate >= PlanDate.AddMonths(-36) && l.LogDate < PlanDate.AddMonths(-24))
                .OrderBy(l => l.LogDate)
                .AsNoTracking()
                .ToList();

            PriorYear = context.LogEntries
                .Where(l => l.ClassId == ClassId)
                .Where(l => l.StoreId == StoreId)
                .Where(l => l.LogDate >= PlanDate.AddMonths(-24) && l.LogDate < PlanDate.AddMonths(-12))
                .OrderBy(l => l.LogDate)
                .AsNoTracking()
                .ToList();

            CurrentYear = context.LogEntries
                .Where(l => l.ClassId == ClassId)
                .Where(l => l.StoreId == StoreId)
                .Where(l => l.LogDate >= PlanDate.AddMonths(-12) && l.LogDate < PlanDate)
                .OrderBy(l => l.LogDate)
                .AsNoTracking()
                .ToList();

            NextYear = context.LogEntries
                .Where(l => l.ClassId == ClassId)
                .Where(l => l.StoreId == StoreId)
                .Where(l => l.LogDate >= PlanDate && l.LogDate < PlanDate.AddMonths(12))
                .OrderBy(l => l.LogDate)
                .AsNoTracking()
                .ToList();

        }

        public DateTime PlanDate { get; set; }

        public int? StoreId { get; set; }
        public int? ClassId { get; set; }

        public IEnumerable<LogEntries> TwoPriorYear { get; set; }
        public IEnumerable<LogEntries> PriorYear { get; set; }
        public IEnumerable<LogEntries> CurrentYear { get; set; }
        public IEnumerable<LogEntries> NextYear { get; set; }
    }
}
