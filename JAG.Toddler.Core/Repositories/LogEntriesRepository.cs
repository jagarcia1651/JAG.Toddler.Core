using JAG.Toddler.Core.Models.Default;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JAG.Toddler.Core.Repository
{
    public class LogEntriesRepository : ILogEntriesRepository
    {
        private JAGToddlerDatabaseContext _context;

        public LogEntriesRepository(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        public void DeleteLogEntry(int storeId, int classId, DateTime logDate)
        {
            LogEntries temp = _context.LogEntries.Find(logDate, storeId, classId);
            _context.LogEntries.Remove(temp);

        }

        public IEnumerable<LogEntries> GetLogEntries(int storeId, int classId, DateTime from, DateTime until)
        {
            IEnumerable<LogEntries> entryList = _context.LogEntries
                .Where(l => l.ClassId == classId)
                .Where(l => l.StoreId == storeId)
                .Where(l => l.LogDate >= from && l.LogDate < until)
                .OrderBy(l => l.LogDate)
                .ToList();

            return entryList;
        }

        public LogEntries GetLogEntry(int storeId, int classId, DateTime logDate)
        {
            return _context.LogEntries.Find(logDate, storeId, classId);
        }

        public void InsertLogEntry(LogEntries logEntry)
        {
            _context.LogEntries.Add(logEntry);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateLogEntry(LogEntries logEntry)
        {
            _context.Entry(logEntry).State = EntityState.Modified;
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
