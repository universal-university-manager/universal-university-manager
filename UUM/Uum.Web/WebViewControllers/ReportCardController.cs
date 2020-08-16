using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.Model.ViewModels;

namespace UUM.WEB.WebViewControllers
{
    public class ReportCardController : Controller
    {
        private readonly Context _context;

        public ReportCardController(Context context)
        {
            _context = context;
        }

        // GET: ReportCard
        public async Task<IActionResult> Index()
        {
            return View(await _context.Newsletters.ToListAsync());
        }

        // GET: ReportCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCardModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportCardModel == null)
            {
                return NotFound();
            }

            return View(reportCardModel);
        }

        // GET: ReportCard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AverageGrade,P1,P2,Sub,Exa,Presence,Fouls,Frequency")] ReportCardModel reportCardModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportCardModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportCardModel);
        }

        // GET: ReportCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCardModel = await _context.Newsletters.FindAsync(id);
            if (reportCardModel == null)
            {
                return NotFound();
            }
            return View(reportCardModel);
        }

        // POST: ReportCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AverageGrade,P1,P2,Sub,Exa,Presence,Fouls,Frequency")] ReportCardModel reportCardModel)
        {
            if (id != reportCardModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportCardModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportCardModelExists(reportCardModel.Id))
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
            return View(reportCardModel);
        }

        // GET: ReportCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCardModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportCardModel == null)
            {
                return NotFound();
            }

            return View(reportCardModel);
        }

        // POST: ReportCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportCardModel = await _context.Newsletters.FindAsync(id);
            _context.Newsletters.Remove(reportCardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportCardModelExists(int id)
        {
            return _context.Newsletters.Any(e => e.Id == id);
        }
    }
}
