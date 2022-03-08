using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSO.BO.Data;
using SSO.BO.Entities;

namespace SSO.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTypesController : ControllerBase
    {
        private readonly SSOContext _context;

        public LoginTypesController(SSOContext context)
        {
            _context = context;
        }

        // GET: api/LoginTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginType>>> GetLoginType()
        {
            return await _context.LoginType.ToListAsync();
        }

        // GET: api/LoginTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginType>> GetLoginType(short id)
        {
            var loginType = await _context.LoginType.FindAsync(id);

            if (loginType == null)
            {
                return NotFound();
            }

            return loginType;
        }

        // PUT: api/LoginTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginType(short id, LoginType loginType)
        {
            if (id != loginType.Id)
            {
                return BadRequest();
            }

            _context.Entry(loginType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginTypeExists(id))
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

        // POST: api/LoginTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoginType>> PostLoginType(LoginType loginType)
        {
            _context.LoginType.Add(loginType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginType", new { id = loginType.Id }, loginType);
        }

        // DELETE: api/LoginTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginType>> DeleteLoginType(short id)
        {
            var loginType = await _context.LoginType.FindAsync(id);
            if (loginType == null)
            {
                return NotFound();
            }

            _context.LoginType.Remove(loginType);
            await _context.SaveChangesAsync();

            return loginType;
        }

        private bool LoginTypeExists(short id)
        {
            return _context.LoginType.Any(e => e.Id == id);
        }
    }
}
