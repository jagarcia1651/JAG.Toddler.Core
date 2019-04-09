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
        public ViewResult Index()
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
        //Parameters: DateTime{planDate}, int{storeId}, int{classId}
        //Description: Navigates to the Planning view and populates data based on store and classification selection.
        [HttpGet]
        public ViewResult Populate(DateTime SelectedPlanDate, int SelectedStoreId, int SelectedClassId)
        {

            PlanningViewModel planningViewModel = new PlanningViewModel(_context, SelectedPlanDate, SelectedStoreId, SelectedClassId);
            return View("Index", planningViewModel);
            
        }

        //POST: Planning
        //Parameters: planningViewModel
        //Description: Updates relevant log entries based on planningViewModel criteria.
        [HttpPost]
        public ViewResult Save(PlanningViewModel plan)
        {
            //Do some validation here.

            PlanningViewModel planningViewModel = new PlanningViewModel(_context, plan.SelectedPlanDate, plan.SelectedStoreId, plan.SelectedClassId);

            int idx = 0;
            foreach(LogEntries entry in planningViewModel.PlanningModel.NextYear)
            {
                entry.SalesPlan = plan.PlanningModel.NextYear.ElementAt(idx).SalesPlan;
                entry.StockPlanRatio = plan.PlanningModel.NextYear.ElementAt(idx).StockPlanRatio;
                entry.StockPlan = plan.PlanningModel.NextYear.ElementAt(idx).StockPlan;
                entry.MarkdownsPlanRatio = plan.PlanningModel.NextYear.ElementAt(idx).MarkdownsPlanRatio;
                entry.SalesPlan = plan.PlanningModel.NextYear.ElementAt(idx).SalesPlan;
                entry.RecAtRetailPlan = plan.PlanningModel.NextYear.ElementAt(idx).RecAtRetailPlan;
                idx++;
            }

            planningViewModel.PlanningModel.Save();
            

            return View("Index", planningViewModel);
        }
    }
}