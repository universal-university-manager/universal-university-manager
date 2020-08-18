using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.CORE.ViewModels;

namespace UUM.API.Controllers
{
    /// <summary>
    /// Address Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">context instance</param>
        public AddressController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns>Address information</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetAddresses() => await _context.Addresses.ToListAsync();

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressModel>> GetAddressModel(int id)
        {
            var addressModel = await _context.Addresses.FindAsync(id);

            if (addressModel == null)
                return NotFound();

            return addressModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <param name="addressModel">addressModel instance</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddressModel(int id, AddressModel addressModel)
        {
            if (id != addressModel.Id)
                return BadRequest();

            _context.Entry(addressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="addressModel">addressModel instance</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddressModel>> PostAddressModel(AddressModel addressModel)
        {
            await _context.Addresses.AddAsync(addressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddressModel", new { id = addressModel.Id }, addressModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressModel>> DeleteAddressModel(int id)
        {
            var addressModel = await _context.Addresses.FindAsync(id);
            if (addressModel == null)
                return NotFound();

            _context.Addresses.Remove(addressModel);
            await _context.SaveChangesAsync();

            return addressModel;
        }

        private bool AddressModelExists(int id) => _context.Addresses.Any(e => e.Id == id);
    }
}
