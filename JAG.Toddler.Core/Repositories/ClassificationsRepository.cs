using JAG.Toddler.Core.Models.Default;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JAG.Toddler.Core.Repositories
{
    public class ClassificationsRepository : IClassificationsRepository
    {
        private JAGToddlerDatabaseContext _context;

        public ClassificationsRepository(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        public void DeleteClassification(int classId)
        {
            Classifications temp = _context.Classifications.Find(classId);
            _context.Classifications.Remove(temp);
        }

        public IEnumerable<Classifications> GetClassifications()
        {
            return _context.Classifications.ToList();
        }

        public Classifications GetClassification(int classId)
        {
            return _context.Classifications.Find(classId);
        }

        public IEnumerable<Classifications> GetClassificationsByCompany(int companyId)
        {
            IEnumerable<Classifications> classList = _context.Classifications
                .Include(c => c.Dept)
                .Where(c => c.Dept.CompanyId == companyId)
                .Select(c => new Classifications
                {
                    ClassId = c.ClassId,
                    DeptId = c.DeptId,
                    Classes = c.Classes,
                    ClassDescription = c.ClassDescription,
                    InternalClass = c.InternalClass,
                    Mupercent = c.Mupercent
                })
                .ToList();

            return classList;
        }

        public IEnumerable<Classifications> GetClassificationsByStore(int storeId)
        {
            int? companyId = _context.Stores
                .Find(storeId)
                .CompanyId;

            IEnumerable<Classifications> classList = _context.Classifications
                .Include(c => c.Dept)
                .Where(c => c.Dept.CompanyId == companyId)
                .Select(c => new Classifications
                {
                    ClassId = c.ClassId,
                    DeptId = c.DeptId,
                    Classes = c.Classes,
                    ClassDescription = c.ClassDescription,
                    InternalClass = c.InternalClass,
                    Mupercent = c.Mupercent
                })
                .ToList();

            return classList;
        }

        public void InsertClassification(Classifications classification)
        {
            _context.Classifications.Add(classification);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateClassification(Classifications classification)
        {
            _context.Entry(classification).State = EntityState.Modified;
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
