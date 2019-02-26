using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Classifications
    {
        public Classifications()
        {
            LogEntries = new HashSet<LogEntries>();
            Markup = new HashSet<Markup>();
        }

        public int ClassId { get; set; }
        public int? DeptId { get; set; }
        public string Classes { get; set; }
        public string ClassDescription { get; set; }
        public string InternalClass { get; set; }
        public decimal? Mupercent { get; set; }

        public virtual Departments Dept { get; set; }
        public virtual ICollection<LogEntries> LogEntries { get; set; }
        public virtual ICollection<Markup> Markup { get; set; }
    }
}
