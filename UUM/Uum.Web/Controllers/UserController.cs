using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uum.Web.Models;

namespace Uum.Web.Controllers
{
    /// <summary>
    /// Register and modify users
    /// </summary>
    public class UserController : Controller
    {
        private readonly Context _context;

        public UserController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Page View</returns>
        public async Task<IActionResult> Index() => View(await _context.Users.ToListAsync());

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Result of the process</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
                return NotFound();

            return View(userModel);
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Page View</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userModel">User instance</param>
        /// <returns>Result of the process</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,GuardianFullName,CpfCnpj,Age,Tel,TypeUser")] UserModel userModel)
        {
            if (!ModelState.IsValid) return View(userModel);
            _context.Add(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Result of the process</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null) return NotFound();
            return View(userModel);
        }

        /// <summary>
        /// Edit user values
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <param name="userModel">User instance</param>
        /// <returns>Result of the process</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,GuardianFullName,CpfCnpj,Age,Tel,TypeUser")] UserModel userModel)
        {
            if (id != userModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(userModel);
            try
            {
                _context.Update(userModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(userModel.Id))
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
        /// <returns>Result of the process</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null) return NotFound();

            return View(userModel);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Result of the process</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if address exists
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns>Check response</returns>
        private bool UserModelExists(int id) => _context.Users.Any(e => e.Id == id);
    }
}
