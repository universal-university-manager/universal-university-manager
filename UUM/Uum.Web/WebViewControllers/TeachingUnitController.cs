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
    public class TeachingUnitController : Controller
    {
        private readonly Context _context;

        public TeachingUnitController(Context context)
        {
            _context = context;
        }

        // GET: TeachingUnit
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeachingUnits.ToListAsync());
        }

        // GET: TeachingUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingUnitModel = await _context.TeachingUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachingUnitModel == null)
            {
                return NotFound();
            }

            return View(teachingUnitModel);
        }

        // GET: TeachingUnit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeachingUnit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,TypeUnit")] TeachingUnitModel teachingUnitModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachingUnitModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teachingUnitModel);
        }

        // GET: TeachingUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);
            if (teachingUnitModel == null)
            {
                return NotFound();
            }
            return View(teachingUnitModel);
        }

        // POST: TeachingUnit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,TypeUnit")] TeachingUnitModel teachingUnitModel)
        {
            if (id != teachingUnitModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachingUnitModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachingUnitModelExists(teachingUnitModel.Id))
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
            return View(teachingUnitModel);
        }

        // GET: TeachingUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingUnitModel = await _context.TeachingUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachingUnitModel == null)
            {
                return NotFound();
            }

            return View(teachingUnitModel);
        }

        // POST: TeachingUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);
            _context.TeachingUnits.Remove(teachingUnitModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachingUnitModelExists(int id)
        {
            return _context.TeachingUnits.Any(e => e.Id == id);
        }
    }
}
