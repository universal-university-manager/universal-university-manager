using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly Context _context;

        public CoursesController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Index</returns>
        public async Task<IActionResult> Index() => View(await _context.Courses.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Details</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var courseModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseModel == null)
                return NotFound();

            return View(courseModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Create</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="courseModel">courseModel instance</param>
        /// <returns>Create instance</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Curriculum,SchoolPeriods,EvaluationPeriods,BanknoteDeliveryPeriod")] CourseModel courseModel)
        {
            if (!ModelState.IsValid) return View(courseModel);
            _context.Add(courseModel);
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

            var courseModel = await _context.Courses.FindAsync(id);
            if (courseModel == null)
                return NotFound();
            return View(courseModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="courseModel">courseModel instance</param>
        /// <returns>Edit instance</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Curriculum,SchoolPeriods,EvaluationPeriods,BanknoteDeliveryPeriod")] CourseModel courseModel)
        {
            if (id != courseModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(courseModel);
            try
            {
                _context.Update(courseModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseModelExists(courseModel.Id))
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

            var courseModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseModel == null)
                return NotFound();

            return View(courseModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Delete instance</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool CourseModelExists(int id) => _context.Courses.Any(e => e.Id == id);
    }
}
