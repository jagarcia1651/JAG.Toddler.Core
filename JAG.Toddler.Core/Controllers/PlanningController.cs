using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAG.Toddler.Core.Models.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JAG.Toddler.Core.Models;
using Newtonsoft.Json;
using System;

namespace JAG.Toddler.Core.Controllers
{
    public class PlanningController : Controller
    {
        private readonly JAGToddlerDatabaseContext _context;

        public PlanningController(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        // GET: Planning
        //Parameters: None
        //Description: Navigates to the Planning view and provides a list of stores to populate dropdown.
        public async Task<IActionResult> Index()
        {
            Planning planningModel = new Planning
            {
                PlanDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0),

                StoreList = await _context.Stores
                    .OrderBy(s => s.StoreName)
                    .AsNoTracking()
                    .ToListAsync(),

                ClassList = new List<Classifications>()
            };

            return View(planningModel);
        }

        //GET: Planning/GETClassList
        //Parameters: int{storeId}
        //Description: Used to populate class list dropdown upon selecting a store.
        [HttpGet]
        public ActionResult GETClassList(int storeId)
        {
            int? companyId = _context.Stores
                .Find(storeId)
                .CompanyId;

            IEnumerable<Classifications> ClassList = _context.Classifications
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

            return Json(ClassList);
        }

        //GET: Planning/GETLogEntries
        //Parameters: DateTime{planDate}, int{storeId}, int{classId}
        //Description: Returns the info to populate class history and plans.
        [HttpGet]
        public ActionResult GETLogEntries(DateTime planDate, int storeId, int classId)
        {
            Planning planningModel = new Planning();

            planningModel.PlanDate = new DateTime(planDate.Year, planDate.Month, 1, 0, 0, 0);
            planningModel.SelectedStoreId = storeId;
            planningModel.SelectedClassId = classId;

            planningModel.TwoPriorYear = _context.LogEntries
                .Where(l => l.ClassId == planningModel.SelectedClassId)
                .Where(l => l.StoreId == planningModel.SelectedStoreId)
                .Where(l => l.LogDate < planningModel.PlanDate && l.LogDate > planningModel.PlanDate)
                .OrderBy(l => l.LogDate)
                .AsNoTracking()
                .ToList();
                
            return Json(planningModel);
        }
    }
}