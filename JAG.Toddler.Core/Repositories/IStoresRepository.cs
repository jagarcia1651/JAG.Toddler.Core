using JAG.Toddler.Core.Models.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JAG.Toddler.Core.Repositories
{
    public interface IStoresRepository: IDisposable
    {
        IEnumerable<Stores> GetStores();
        Stores GetStore(int storeId);
        void InsertStore(Stores store);
        void DeleteStore(int storeId);
        void UpdateStore(Stores store);
        void Save();
    }
}
