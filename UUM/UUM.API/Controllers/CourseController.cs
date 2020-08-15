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
    /// Course Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CourseController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseModel(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);

            if (courseModel == null)
                return NotFound();

            return courseModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseModel(int id, CourseModel courseModel)
        {
            if (id != courseModel.Id)
                return BadRequest();

            _context.Entry(courseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourseModel(CourseModel courseModel)
        {
            _context.Courses.Add(courseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseModel", new { id = courseModel.Id }, courseModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseModel>> DeleteCourseModel(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);
            if (courseModel == null)
                return NotFound();

            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();

            return courseModel;
        }

        private bool CourseModelExists(int id) => _context.Courses.Any(e => e.Id == id);
    }
}
