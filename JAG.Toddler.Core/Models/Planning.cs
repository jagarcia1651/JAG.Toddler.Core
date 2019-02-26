using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAG.Toddler.Core.Models.Default;

namespace JAG.Toddler.Core.Models
{
    public class Planning
    {
        public Planning()
        {
        }
        public DateTime PlanDate { get; set; }

        public IEnumerable<Stores> StoreList { get; set; }
        public int? SelectedStoreId { get; set; }

        public IEnumerable<Classifications> ClassList { get; set; }
        public int? SelectedClassId { get; set; }

        public IEnumerable<LogEntries> TwoPriorYear { get; set; }
        public IEnumerable<LogEntries> PriorYear { get; set; }
        public IEnumerable<LogEntries> CurrentYear { get; set; }
        public IEnumerable<LogEntries> NextYear { get; set; }
    }
}
