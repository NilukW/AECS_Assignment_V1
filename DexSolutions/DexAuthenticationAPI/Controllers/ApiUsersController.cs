#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DexAuthenticationAPI;
using DexAuthenticationAPI.Data;

namespace DexAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiUsersController : ControllerBase
    {
        private readonly DexAuthenticationAPIContext _context;

        public ApiUsersController(DexAuthenticationAPIContext context)
        {
            _context = context;
        }

        // GET: api/ApiUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiUser>>> GetApiUser()
        {
            return await _context.ApiUser.ToListAsync();
        }

        // GET: api/ApiUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiUser>> GetApiUser(int id)
        {
            var apiUser = await _context.ApiUser.FindAsync(id);

            if (apiUser == null)
            {
                return NotFound();
            }

            return apiUser;
        }

        // PUT: api/ApiUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApiUser(int id, ApiUser apiUser)
        {
            if (id != apiUser.ApiUserId)
            {
                return BadRequest();
            }

            _context.Entry(apiUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiUser>> PostApiUser(ApiUser apiUser)
        {
            _context.ApiUser.Add(apiUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApiUser", new { id = apiUser.ApiUserId }, apiUser);
        }

        // DELETE: api/ApiUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApiUser(int id)
        {
            var apiUser = await _context.ApiUser.FindAsync(id);
            if (apiUser == null)
            {
                return NotFound();
            }

            _context.ApiUser.Remove(apiUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApiUserExists(int id)
        {
            return _context.ApiUser.Any(e => e.ApiUserId == id);
        }
    }
}
