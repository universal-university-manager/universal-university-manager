using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    public class ReportCardController : Controller
    {
        private readonly Context _context;

        public ReportCardController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Index</returns>
        public async Task<IActionResult> Index() => View(await _context.Newsletters.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Details</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var reportCardModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportCardModel == null)
                return NotFound();

            return View(reportCardModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Create</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="reportCardModel">reportCardModel</param>
        /// <returns>Create instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AverageGrade,P1,P2,Sub,Exa,Presence,Fouls,Frequency")] ReportCardModel reportCardModel)
        {
            if (!ModelState.IsValid) return View(reportCardModel);
            _context.Add(reportCardModel);
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

            var reportCardModel = await _context.Newsletters.FindAsync(id);
            if (reportCardModel == null)
                return NotFound();
            return View(reportCardModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="reportCardModel">reportCardModel instances</param>
        /// <returns>Edit instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AverageGrade,P1,P2,Sub,Exa,Presence,Fouls,Frequency")] ReportCardModel reportCardModel)
        {
            if (id != reportCardModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(reportCardModel);
            try
            {
                _context.Update(reportCardModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCardModelExists(reportCardModel.Id))
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

            var reportCardModel = await _context.Newsletters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportCardModel == null)
                return NotFound();

            return View(reportCardModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instances</param>
        /// <returns>Delete instance</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportCardModel = await _context.Newsletters.FindAsync(id);
            _context.Newsletters.Remove(reportCardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool ReportCardModelExists(int id) => _context.Newsletters.Any(e => e.Id == id);
    }
}
