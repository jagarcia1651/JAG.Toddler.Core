using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class Stores
    {
        public Stores()
        {
            Comment = new HashSet<Comment>();
            Expenses = new HashSet<Expenses>();
            LogEntries = new HashSet<LogEntries>();
            Markup = new HashSet<Markup>();
        }

        public int StoreId { get; set; }
        public int? CompanyId { get; set; }
        public int? ConsultId { get; set; }
        public string StoreName { get; set; }
        public string StoreManager { get; set; }
        public string StoreManagerPhone { get; set; }
        public string StoreAddress1 { get; set; }
        public string StoreAddress2 { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }
        public bool? Selected { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public virtual Companies Company { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<LogEntries> LogEntries { get; set; }
        public virtual ICollection<Markup> Markup { get; set; }
    }
}
