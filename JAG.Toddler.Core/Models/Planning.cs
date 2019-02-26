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

        public IEnumerable<Stores> StoreList { get; set; }
        public int? SelectedCompanyId { get; set; }

        public IEnumerable<Classifications> ClassList {get; set;}
        public int? SelectedClassId { get; set; }
    }
}
