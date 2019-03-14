using JAG.Toddler.Core.Models.Default;
using System;
using System.Collections.Generic;

namespace JAG.Toddler.Core.Repository
{
    public interface ILogEntriesRepository : IDisposable
    {
        IEnumerable<LogEntries> GetLogEntries(int storeId, int classId, DateTime from, DateTime until);
        LogEntries GetLogEntry(int storeId, int classId, DateTime logDate);

        void InsertLogEntry(LogEntries logEntry);
        void DeleteLogEntry(int storeId, int classId, DateTime logDate);
        void UpdateLogEntry(LogEntries logEntry);
        void Save();
    }
}
