using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    public class LoginsController : Controller
    {
        private readonly Context _context;

        public LoginsController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Index</returns>
        public async Task<IActionResult> Index() => View(await _context.Logins.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Details</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var loginModel = await _context.Logins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginModel == null)
                return NotFound();

            return View(loginModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Create</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="loginModel">loginModel instances</param>
        /// <returns>Create instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Password")] LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            _context.Add(loginModel);
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

            var loginModel = await _context.Logins.FindAsync(id);
            if (loginModel == null)
                return NotFound();
            return View(loginModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="loginModel">loginModel instances</param>
        /// <returns>Edit instances</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password")] LoginModel loginModel)
        {
            if (id != loginModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(loginModel);
            try
            {
                _context.Update(loginModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(loginModel.Id))
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

            var loginModel = await _context.Logins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginModel == null)
                return NotFound();

            return View(loginModel);
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
            var loginModel = await _context.Logins.FindAsync(id);
            _context.Logins.Remove(loginModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool LoginModelExists(int id) => _context.Logins.Any(e => e.Id == id);
    }
}
