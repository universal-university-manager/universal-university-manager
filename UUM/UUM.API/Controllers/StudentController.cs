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
    /// Student Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public StudentController(Context context) => _context = context;

        // GET: api/StudentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents() => await _context.Students.ToListAsync();

        // GET: api/StudentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(int id)
        {
            var studentModel = await _context.Students.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(int id, StudentModel studentModel)
        {
            if (id != studentModel.Id)
                return BadRequest();

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
            _context.Students.Add(studentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = studentModel.Id }, studentModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentModel>> DeleteStudentModel(int id)
        {
            var studentModel = await _context.Students.FindAsync(id);
            if (studentModel == null)
                return NotFound();

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        private bool StudentModelExists(int id) => _context.Students.Any(e => e.Id == id);
    }
}
