using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UUM.Infrastructure.Context;
using UUM.Model.ViewModels;

namespace UUM.API.Controllers
{
    /// <summary>
    /// Teaching Unit Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingUnitController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TeachingUnitController(Context context) => _context = context;

        // GET: api/TeachingUnitModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachingUnitModel>>> GetTeachingUnits() => await _context.TeachingUnits.ToListAsync();

        // GET: api/TeachingUnitModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeachingUnitModel>> GetTeachingUnitModel(int id)
        {
            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);

            if (teachingUnitModel == null)
                return NotFound();

            return teachingUnitModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teachingUnitModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachingUnitModel(int id, TeachingUnitModel teachingUnitModel)
        {
            if (id != teachingUnitModel.Id)
                return BadRequest();

            _context.Entry(teachingUnitModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachingUnitModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="teachingUnitModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TeachingUnitModel>> PostTeachingUnitModel(TeachingUnitModel teachingUnitModel)
        {
            _context.TeachingUnits.Add(teachingUnitModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeachingUnitModel", new { id = teachingUnitModel.Id }, teachingUnitModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeachingUnitModel>> DeleteTeachingUnitModel(int id)
        {
            var teachingUnitModel = await _context.TeachingUnits.FindAsync(id);
            if (teachingUnitModel == null)
                return NotFound();

            _context.TeachingUnits.Remove(teachingUnitModel);
            await _context.SaveChangesAsync();

            return teachingUnitModel;
        }

        private bool TeachingUnitModelExists(int id) => _context.TeachingUnits.Any(e => e.Id == id);
    }
}
