﻿using System;
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
    public class UserTypesController : ControllerBase
    {
        private readonly SSOContext _context;

        public UserTypesController(SSOContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserType()
        {
            return await _context.UserType.ToListAsync();
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(short id)
        {
            var userType = await _context.UserType.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        // PUT: api/UserTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(short id, UserType userType)
        {
            if (id != userType.Id)
            {
                return BadRequest();
            }

            _context.Entry(userType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        // POST: api/UserTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType(UserType userType)
        {
            _context.UserType.Add(userType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = userType.Id }, userType);
        }

        // DELETE: api/UserTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserType>> DeleteUserType(short id)
        {
            var userType = await _context.UserType.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }

            _context.UserType.Remove(userType);
            await _context.SaveChangesAsync();

            return userType;
        }

        private bool UserTypeExists(short id)
        {
            return _context.UserType.Any(e => e.Id == id);
        }
    }
}
