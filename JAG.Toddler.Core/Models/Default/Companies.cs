using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Companies
    {
        public Companies()
        {
            Departments = new HashSet<Departments>();
            ReportSelect = new HashSet<ReportSelect>();
            Stores = new HashSet<Stores>();
        }

        public int CompanyId { get; set; }
        public string Company { get; set; }
        public byte? StartFiscalYear { get; set; }
        public string Owner { get; set; }
        public string ComAddress1 { get; set; }
        public string ComAddess2 { get; set; }
        public string ComCity { get; set; }
        public string ComState { get; set; }
        public string ComZip { get; set; }
        public string OwnerPhone { get; set; }
        public int? ConsultId { get; set; }

        public virtual Consultants Consult { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<ReportSelect> ReportSelect { get; set; }
        public virtual ICollection<Stores> Stores { get; set; }
    }
}
