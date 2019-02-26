using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Comment
    {
        public DateTime LogDate { get; set; }
        public int StoreId { get; set; }
        public string Comment1 { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Stores Store { get; set; }
    }
}
