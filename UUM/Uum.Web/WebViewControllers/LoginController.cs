using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.Model.ViewModels;

namespace UUM.WEB.WebViewControllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context) => _context = context;

        // GET: Login
        public async Task<IActionResult> Index() => View(await _context.Logins.ToListAsync());

        // GET: Login/Details/5
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

        // GET: Login/Create
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Password")] LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            _context.Add(loginModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Login/Edit/5
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
        /// <param name="id"></param>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password")] LoginModel loginModel)
        {
            if (id != loginModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginModelExists(loginModel.Id))
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
            return View(loginModel);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginModel = await _context.Logins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginModel == null)
            {
                return NotFound();
            }

            return View(loginModel);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginModel = await _context.Logins.FindAsync(id);
            _context.Logins.Remove(loginModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginModelExists(int id)
        {
            return _context.Logins.Any(e => e.Id == id);
        }
    }
}
