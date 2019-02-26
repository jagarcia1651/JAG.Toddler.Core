using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Markup
    {
        public int StoreId { get; set; }
        public int ClassId { get; set; }
        public decimal? Mupercent { get; set; }
        public bool? Otb { get; set; }
        public bool? Report { get; set; }
        public bool? Locked { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Classifications Class { get; set; }
        public virtual Stores Store { get; set; }
    }
}
