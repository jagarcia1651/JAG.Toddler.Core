using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JAG.Toddler.Core.Models.Default;

namespace JAG.Toddler.Core.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly JAGToddlerDatabaseContext _context;

        public CompaniesController(JAGToddlerDatabaseContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var jAGToddlerDatabaseContext = _context.Companies.Include(c => c.Consult);
            return View(await jAGToddlerDatabaseContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies
                .Include(c => c.Consult)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["ConsultId"] = new SelectList(_context.Consultants, "ConsultId", "ConsultId");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,Company,StartFiscalYear,Owner,ComAddress1,ComAddess2,ComCity,ComState,ComZip,OwnerPhone,ConsultId")] Companies companies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultId"] = new SelectList(_context.Consultants, "ConsultId", "ConsultId", companies.ConsultId);
            return View(companies);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies.FindAsync(id);
            if (companies == null)
            {
                return NotFound();
            }
            ViewData["ConsultId"] = new SelectList(_context.Consultants, "ConsultId", "ConsultId", companies.ConsultId);
            return View(companies);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,Company,StartFiscalYear,Owner,ComAddress1,ComAddess2,ComCity,ComState,ComZip,OwnerPhone,ConsultId")] Companies companies)
        {
            if (id != companies.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesExists(companies.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultId"] = new SelectList(_context.Consultants, "ConsultId", "ConsultId", companies.ConsultId);
            return View(companies);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies
                .Include(c => c.Consult)
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (companies == null)
            {
                return NotFound();
            }

            return View(companies);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companies = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(companies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompaniesExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
