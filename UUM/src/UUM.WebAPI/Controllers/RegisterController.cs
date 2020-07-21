using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UUM.WebAPI.Data;
using UUM.WebAPI.Models;

namespace UUM.ApiWeb.Controllers
{
    public class RegisterController : Controller
    {
        /// <summary>
        /// Logger properties
        /// </summary>
        private readonly ILogger<RegisterController> _logger;

        /// <summary>
        /// Context properties
        /// </summary>
        private readonly UUMWebAPIContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Context instance</param>
        public RegisterController(UUMWebAPIContext context) => _context = context;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>View page</returns>
        public async Task<IActionResult> Index() => View(await _context.Register.ToListAsync());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var register = await _context.Register.FirstOrDefaultAsync(m => m.Id == id);
            
            if (register == null) return NotFound();

            return View(register);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Register/Create
        /// </summary>
        /// <param name="register">register instance</param>
        /// <returns>result for instances in method create</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,CpfCnpj,Age")] Register register)
        {
            if (!ModelState.IsValid) return View(register);
            _context.Add(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var register = await _context.Register.FindAsync(id);
            
            if (register == null) return NotFound();
            
            return View(register);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id isntance</param>
        /// <param name="register">Register instance</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,CpfCnpj,Age")] Register register)
        {
            if (id != register.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(register);
            try
            {
                _context.Update(register);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(register.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
                return NotFound();

            return View(register);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Register.FindAsync(id);
            _context.Register.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns></returns>
        private bool RegisterExists(int id) => _context.Register.Any(e => e.Id == id);
    }
}
