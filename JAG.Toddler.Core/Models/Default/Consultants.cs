using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Consultants
    {
        public Consultants()
        {
            Companies = new HashSet<Companies>();
        }

        public int ConsultId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
    }
}
