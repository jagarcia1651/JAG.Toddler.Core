using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Expenses
    {
        public int StoreId { get; set; }
        public DateTime LogDate { get; set; }
        public int? Expenses1 { get; set; }

        public virtual Stores Store { get; set; }
    }
}
