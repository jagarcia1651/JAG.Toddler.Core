using JAG.Toddler.Core.Models.Default;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JAG.Toddler.Core.Repositories
{
    public class StoresRepository : IStoresRepository
    {
        private JAGToddlerDatabaseContext _context;

        public StoresRepository(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        public void DeleteStore(int storeId)
        {
            Stores temp = _context.Stores.Find(storeId);
            _context.Stores.Remove(temp);
        }

        public Stores GetStore(int storeId)
        {
            return _context.Stores.Find(storeId);
        }

        public IEnumerable<Stores> GetStores()
        {
            return _context.Stores.ToList();
        }

        public void InsertStore(Stores store)
        {
            _context.Stores.Add(store);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateStore(Stores store)
        {
            _context.Entry(store).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
