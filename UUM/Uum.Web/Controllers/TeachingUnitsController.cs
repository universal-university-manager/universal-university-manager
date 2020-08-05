using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    public class TeachingUnitsController : Controller
    {
        private readonly Context _context;

        public TeachingUnitsController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Index</returns>
        public async Task<IActionResult> Index() => View(await _context.TeachingUnits.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Details</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var teachingUnitModel = await _context.TeachingUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachingUnitModel == null)
                return NotFound();

            return View(teachingUnitModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Create</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="teachingUnitModel">teachingUnitModel instance</param>
        /// <returns>Create instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,TypeUnit")] TeachingUnitModel teachingUnitModel)
        {
            if (!ModelState.IsValid) return View(teachingUnitModel);
            _context.Add(teachingUnitModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Edit</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);
            if (teachingUnitModel == null)
                return NotFound();
            return View(teachingUnitModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="teachingUnitModel">teachingUnitModel instance</param>
        /// <returns>Edit instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,TypeUnit")] TeachingUnitModel teachingUnitModel)
        {
            if (id != teachingUnitModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(teachingUnitModel);
            try
            {
                _context.Update(teachingUnitModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachingUnitModelExists(teachingUnitModel.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Delete</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var teachingUnitModel = await _context.TeachingUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachingUnitModel == null)
                return NotFound();

            return View(teachingUnitModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Delete instances</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);
            _context.TeachingUnits.Remove(teachingUnitModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool TeachingUnitModelExists(int id) => _context.TeachingUnits.Any(e => e.Id == id);
    }
}
