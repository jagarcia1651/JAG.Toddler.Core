using JAG.Toddler.Core.Models.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JAG.Toddler.Core.Repositories
{
    public interface IClassificationsRepository : IDisposable
    {
        IEnumerable<Classifications> GetClassifications();
        IEnumerable<Classifications> GetClassificationsByStore(int storeId);
        IEnumerable<Classifications> GetClassificationsByCompany(int companyId);
        Classifications GetClassification(int classId);
        void InsertClassification(Classifications classification);
        void DeleteClassification(int classId);
        void UpdateClassification(Classifications classification);
        void Save();
    }
}
