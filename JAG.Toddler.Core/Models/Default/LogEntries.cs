using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class LogEntries
    {
        public DateTime LogDate { get; set; }
        public int StoreId { get; set; }
        public int ClassId { get; set; }
        public int? Sales { get; set; }
        public int? Markdowns { get; set; }
        public int? Markups { get; set; }
        public int? VendorReturnRetail { get; set; }
        public int? ReceivedAtRetail { get; set; }
        public int? ReceivedAtCost { get; set; }
        public int? TransfersIn { get; set; }
        public int? TransfersOut { get; set; }
        public int? Ufac1o { get; set; }
        public int? Ufac2o { get; set; }
        public int? Ufac3o { get; set; }
        public int? Ufac4o { get; set; }
        public int? Ufac5o { get; set; }
        public int? Ufac6o { get; set; }
        public int? Ufac7o { get; set; }
        public int? Ufac8o { get; set; }
        public int? Ufac9o { get; set; }
        public int? Ufac10o { get; set; }
        public int? SalesPlan { get; set; }
        public decimal? StockPlanRatio { get; set; }
        public int? StockPlan { get; set; }
        public decimal? MarkdownsPlanRatio { get; set; }
        public int? RecAtRetailPlan { get; set; }
        public int? Stocks { get; set; }
        public int? StocksNext { get; set; }
        public bool? Physical { get; set; }
        public bool? PhysicalNext { get; set; }
        public DateTime? TimeStamp { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Classifications Class { get; set; }
        public virtual Stores Store { get; set; }
    }
}
