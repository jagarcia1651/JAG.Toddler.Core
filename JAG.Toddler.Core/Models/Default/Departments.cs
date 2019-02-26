using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Departments
    {
        public Departments()
        {
            Classifications = new HashSet<Classifications>();
        }

        public int DeptId { get; set; }
        public int? CompanyId { get; set; }
        public string DeptName { get; set; }
        public string DeptDescription { get; set; }

        public virtual Companies Company { get; set; }
        public virtual ICollection<Classifications> Classifications { get; set; }
    }
}
