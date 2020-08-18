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
    /// User Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Context instance</param>
        public UserController(Context context) => _context = context;

        // GET: api/UserModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers() => await _context.Users.ToListAsync();

        // GET: api/UserModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);

            if (userModel == null)
                return NotFound();

            return userModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id">id instance</param>
        /// <param name="userModel">userModel instance</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, UserModel userModel)
        {
            if (id != userModel.Id)
                return BadRequest();

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="userModel">userModel Instance</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserModel(UserModel userModel)
        {
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.Id }, userModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id">Id instance</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null)
                return NotFound();

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        private bool UserModelExists(int id) => _context.Users.Any(e => e.Id == id);
    }
}
