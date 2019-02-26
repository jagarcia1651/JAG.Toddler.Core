using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class ReportSelect
    {
        public int CompanyId { get; set; }
        public int ReportId { get; set; }

        public virtual Companies Company { get; set; }
    }
}
