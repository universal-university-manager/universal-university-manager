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
    /// Report Card Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportCardController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ReportCardController(Context context) => _context = context;

        // GET: api/ReportCardModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportCardModel>>> GetNewsletters() => await _context.Newsletters.ToListAsync();

        // GET: api/ReportCardModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportCardModel>> GetReportCardModel(int id)
        {
            var reportCardModel = await _context.Newsletters.FindAsync(id);

            if (reportCardModel == null)
                return NotFound();

            return reportCardModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reportCardModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportCardModel(int id, ReportCardModel reportCardModel)
        {
            if (id != reportCardModel.Id)
                return BadRequest();

            _context.Entry(reportCardModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportCardModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="reportCardModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ReportCardModel>> PostReportCardModel(ReportCardModel reportCardModel)
        {
            _context.Newsletters.Add(reportCardModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportCardModel", new { id = reportCardModel.Id }, reportCardModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReportCardModel>> DeleteReportCardModel(int id)
        {
            var reportCardModel = await _context.Newsletters.FindAsync(id);
            if (reportCardModel == null)
                return NotFound();

            _context.Newsletters.Remove(reportCardModel);
            await _context.SaveChangesAsync();

            return reportCardModel;
        }

        private bool ReportCardModelExists(int id) => _context.Newsletters.Any(e => e.Id == id);
    }
}
