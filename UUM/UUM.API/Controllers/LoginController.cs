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
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public LoginController(Context context) => _context = context;

        /// <summary>
        /// GET Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetLogins() => await _context.Logins.ToListAsync();

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModel>> GetLoginModel(int id)
        {
            var loginModel = await _context.Logins.FindAsync(id);

            if (loginModel == null)
                return NotFound();

            return loginModel;
        }

        /// <summary>
        /// PUT Method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginModel(int id, LoginModel loginModel)
        {
            if (id != loginModel.Id)
                return BadRequest();

            _context.Entry(loginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LoginModel>> PostLoginModel(LoginModel loginModel)
        {
            _context.Logins.Add(loginModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginModel", new { id = loginModel.Id }, loginModel);
        }

        /// <summary>
        /// DELETE Method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginModel>> DeleteLoginModel(int id)
        {
            var loginModel = await _context.Logins.FindAsync(id);
            if (loginModel == null)
                return NotFound();

            _context.Logins.Remove(loginModel);
            await _context.SaveChangesAsync();

            return loginModel;
        }

        private bool LoginModelExists(int id) => _context.Logins.Any(e => e.Id == id);
    }
}
