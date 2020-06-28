using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.WebAPI.Data;
using UUM.WebAPI.Models;

namespace UUM.WebAPI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UUMWebAPIContext _context;

        public RegisterController(UUMWebAPIContext context) => _context = context;

        // GET: Register
        public async Task<IActionResult> Index() => View(await _context.Register.ToListAsync());

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
                return NotFound();

            return View(register);
        }

        // GET: Register/Create
        public IActionResult Create() => View();

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,CpfCnpj,Age")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var register = await _context.Register.FindAsync(id);
            if (register == null)
                return NotFound();
            return View(register);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,CpfCnpj,Age")] Register register)
        {
            if (id != register.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Register/Delete/5
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

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Register.FindAsync(id);
            _context.Register.Remove(register);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id) => _context.Register.Any(e => e.Id == id);
    }
}
