using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.Model.ViewModels;

namespace UUM.WEB.WebViewControllers
{
    public class AddressController : Controller
    {
        private readonly Context _context;

        public AddressController(Context context) => _context = context;

        // GET: Address
        public async Task<IActionResult> Index() => View(await _context.Addresses.ToListAsync());

        // GET: Address/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var addressModel = await _context.Addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
            {
                return NotFound();
            }

            return View(addressModel);
        }

        // GET: Address/Create
        public IActionResult Create() => View();

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="addressModel">addressModel instance</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,State,City,Street,Number,ZipCode")] AddressModel addressModel)
        {
            if (!ModelState.IsValid) return View(addressModel);
            _context.Add(addressModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var addressModel = await _context.Addresses.FindAsync(id);
            if (addressModel == null)
                return NotFound();
            return View(addressModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <param name="addressModel">addressModel instance</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,State,City,Street,Number,ZipCode")] AddressModel addressModel)
        {
            if (id != addressModel.Id)
                return NotFound();

            if (!ModelState.IsValid) return View(addressModel);
            try
            {
                _context.Update(addressModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressModelExists(addressModel.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var addressModel = await _context.Addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressModel == null)
                return NotFound();

            return View(addressModel);
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressModel = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(addressModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressModelExists(int id) => _context.Addresses.Any(e => e.Id == id);
    }
}
