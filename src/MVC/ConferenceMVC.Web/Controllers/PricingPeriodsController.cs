using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConferenceMVC.Domain.Entities;
using ConferenceMVC.Infrastucture;

namespace ConferenceMVC.Web.Controllers
{
    public class PricingPeriodsController : Controller
    {
        private readonly ConferenceContext _context;

        public PricingPeriodsController(ConferenceContext context)
        {
            _context = context;
        }

        // GET: PricingPeriods
        public async Task<IActionResult> Index()
        {
            var conferenceContext = _context.PricingPeriods.Include(p => p.Conference);
            return View(await conferenceContext.ToListAsync());
        }

        // GET: PricingPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricingPeriod = await _context.PricingPeriods
                .Include(p => p.Conference)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricingPeriod == null)
            {
                return NotFound();
            }

            return View(pricingPeriod);
        }

        // GET: PricingPeriods/Create
        public IActionResult Create()
        {
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name");
            return View();
        }

        // POST: PricingPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price,StartDate,EndDate,ConferenceId,Id")] PricingPeriod pricingPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricingPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", pricingPeriod.ConferenceId);
            return View(pricingPeriod);
        }

        // GET: PricingPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricingPeriod = await _context.PricingPeriods.FindAsync(id);
            if (pricingPeriod == null)
            {
                return NotFound();
            }
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", pricingPeriod.ConferenceId);
            return View(pricingPeriod);
        }

        // POST: PricingPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,StartDate,EndDate,ConferenceId,Id")] PricingPeriod pricingPeriod)
        {
            if (id != pricingPeriod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricingPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricingPeriodExists(pricingPeriod.Id))
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
            ViewData["ConferenceId"] = new SelectList(_context.Conferences, "Id", "Name", pricingPeriod.ConferenceId);
            return View(pricingPeriod);
        }

        // GET: PricingPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricingPeriod = await _context.PricingPeriods
                .Include(p => p.Conference)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricingPeriod == null)
            {
                return NotFound();
            }

            return View(pricingPeriod);
        }

        // POST: PricingPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pricingPeriod = await _context.PricingPeriods.FindAsync(id);
            if (pricingPeriod != null)
            {
                _context.PricingPeriods.Remove(pricingPeriod);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricingPeriodExists(int id)
        {
            return _context.PricingPeriods.Any(e => e.Id == id);
        }
    }
}
