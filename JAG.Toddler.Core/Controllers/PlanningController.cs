using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAG.Toddler.Core.Models.Default;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JAG.Toddler.Core.Models;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Index()
        {
            Planning planningModel = new Planning();
            planningModel.StoreList = await _context.Stores.AsNoTracking().ToListAsync();

            planningModel.ClassList = new List<Classifications>();

            return View(planningModel);
        }

        [HttpGet]
        public ActionResult GETClassList(int companyId)
        {
            IEnumerable<Classifications> ClassList = _context.Classifications
                .Include(c => c.Dept)
                .Where(c => c.Dept.CompanyId == companyId)
                .Select(c => new Classifications
                {
                    Classes = c.Classes,
                    ClassId = c.ClassId
                })
                .AsNoTracking()
                .ToList();

            return Json(ClassList);
        }
    }
}