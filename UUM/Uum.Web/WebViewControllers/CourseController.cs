using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.Model.ViewModels;

namespace UUM.WEB.WebViewControllers
{
    public class CourseController : Controller
    {
        private readonly Context _context;

        public CourseController(Context context) => _context = context;

        // GET: Course
        public async Task<IActionResult> Index() => View(await _context.Courses.ToListAsync());

        // GET: Course/Details/5
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

        // GET: Course/Create
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="courseModel"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseModelExists(int id) => _context.Courses.Any(e => e.Id == id);
    }
}
