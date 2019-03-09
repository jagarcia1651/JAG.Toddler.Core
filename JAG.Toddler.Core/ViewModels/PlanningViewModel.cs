using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JAG.Toddler.Core.Models;
using JAG.Toddler.Core.Models.Default;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JAG.Toddler.Core.ViewModels
{
    //#TODO
    //Determine if a ViewModel can interact with a DB directly.  If not, wrap DB access in Model methods.
    public class PlanningViewModel
    {
        public PlanningViewModel(JAGToddlerDatabaseContext context)
        {
            SelectedPlanDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

            StoreList = context.Stores
                .OrderBy(s => s.StoreName)
                .AsNoTracking()
                .ToList();
            SelectedStoreId = 0;
            StoreSelect = new SelectList(StoreList, "StoreId", "StoreName", SelectedStoreId);

            ClassList = new List<Classifications>();
            SelectedClassId = 0;
            ClassSelect = new SelectList(ClassList, "ClassId", "Classes", SelectedClassId);

            PlanningModel = new Planning(context);
        }

        public PlanningViewModel(JAGToddlerDatabaseContext context, DateTime planDate, int storeId, int classId)
        {
            SelectedPlanDate = new DateTime(planDate.Year, planDate.Month, 1, 0, 0, 0);

            StoreList = context.Stores
                .OrderBy(s => s.StoreName)
                .AsNoTracking()
                .ToList();
            SelectedStoreId = storeId;
            StoreSelect = new SelectList(StoreList, "StoreId", "StoreName", SelectedStoreId);

            //#TODO
            //Should this search StoreList instead even though I would need to use a loop?
            int? companyId = context.Stores
                .Find(storeId)
                .CompanyId;
            ClassList = context.Classifications
                .Include(c => c.Dept)
                .Where(c => c.Dept.CompanyId == companyId)
                .Select(c => new Classifications
                {
                    Classes = c.Classes,
                    ClassId = c.ClassId
                })
                .OrderBy(c => c.Classes)
                .AsNoTracking()
                .ToList();
            SelectedClassId = classId;
            ClassSelect = new SelectList(ClassList, "ClassId", "Classes", SelectedClassId);

            PlanningModel = new Planning(context, SelectedPlanDate, SelectedStoreId, SelectedClassId);
        }

        public DateTime SelectedPlanDate { get; set; }

        IEnumerable<Stores> StoreList { get; set; }
        public int SelectedStoreId { get; set; }
        public SelectList StoreSelect { get; set; }

        IEnumerable<Classifications> ClassList { get; set; }
        public int SelectedClassId { get; set; }
        public SelectList ClassSelect { get; set; }

        public Planning PlanningModel { get; set; }
    }
}
