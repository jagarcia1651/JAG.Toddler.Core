using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAG.Toddler.Core.Models.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JAG.Toddler.Core.ViewModels;
using System;

namespace JAG.Toddler.Core.Controllers
{
    //#TODO
    //Resolve action types on controller  methods.
    public class PlanningController : Controller
    {
        private readonly JAGToddlerDatabaseContext _context;

        public PlanningController(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        // GET: Planning
        //Parameters: JAGToddlerDatabaseContext{context}
        //Description: Navigates to the Planning view and provides a list of stores to populate dropdown.
        public async Task<IActionResult> Index()
        {
            PlanningViewModel planningViewModel = new PlanningViewModel(_context);

            return View(planningViewModel);
        }

        //GET: Planning/GETClassList
        //Parameters: int{storeId}
        //Description: Used to populate class list dropdown upon selecting a store.
        [HttpGet]
        public ActionResult GETClassList(int storeId)
        {
            //#TODO
            //This same sequence exists in the PopulatePlanning constructor.  Should I wrap it, and if so where should that method live?
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

        // GET: Planning
        //Parameters: JAGToddlerDatabaseContext{context}, DateTime{planDate}, int{storeId}, int{classId}
        //Description: Navigates to the Planning view and provides a list of stores to populate dropdown.
        [HttpGet]
        public async Task<IActionResult> Populate(DateTime SelectedPlanDate, int SelectedStoreId, int SelectedClassId)
        {
            //#TODO
            //It seems like I should only have to have one return statement after the conditional.
            if(SelectedStoreId == 0)
            {
                PlanningViewModel planningViewModel = new PlanningViewModel(_context);
                return View("Index", planningViewModel);
            }
            else
            {
                PlanningViewModel planningViewModel = new PlanningViewModel(_context, SelectedPlanDate, SelectedStoreId, SelectedClassId);
                return View("Index", planningViewModel);
            }
        }
    }
}