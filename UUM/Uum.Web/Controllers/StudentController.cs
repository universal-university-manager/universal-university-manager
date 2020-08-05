using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly Context _context;

        public StudentController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Index</returns>
        public async Task<IActionResult> Index() => View(await _context.Students.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Details</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var studentModel = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentModel == null)
                return NotFound();

            return View(studentModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Create</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="studentModel">studentModel instance</param>
        /// <returns>Create instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationDate,CompletionDate,TransferDate,LockoutDate")] StudentModel studentModel)
        {
            if (!ModelState.IsValid) return View(studentModel);
            _context.Add(studentModel);
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

            var studentModel = await _context.Students.FindAsync(id);
            if (studentModel == null)
                return NotFound();
            return View(studentModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="studentModel">studentModel instance</param>
        /// <returns>Edit instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationDate,CompletionDate,TransferDate,LockoutDate")] StudentModel studentModel)
        {
            if (id != studentModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(studentModel);
            try
            {
                _context.Update(studentModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(studentModel.Id))
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

            var studentModel = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentModel == null)
                return NotFound();

            return View(studentModel);
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
            var studentModel = await _context.Students.FindAsync(id);
            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool StudentModelExists(int id) => _context.Students.Any(e => e.Id == id);
    }
}
