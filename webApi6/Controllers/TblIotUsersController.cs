#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi6;

namespace webApi6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblIotUsersController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblIotUsersController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblIotUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblIotUsers>>> GetTblIotUsers()
        {
            return await _context.TblIotUsers.ToListAsync();
        }

        // GET: api/TblIotUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblIotUsers>> GetTblIotUsers(int id)
        {
            var tblIotUsers = await _context.TblIotUsers.FindAsync(id);

            if (tblIotUsers == null)
            {
                return NotFound();
            }

            return tblIotUsers;
        }

        // PUT: api/TblIotUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblIotUsers(int id, TblIotUsers tblIotUsers)
        {
            if (id != tblIotUsers.IotId)
            {
                return BadRequest();
            }

            _context.Entry(tblIotUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblIotUsersExists(id))
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

        // POST: api/TblIotUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblIotUsers>> PostTblIotUsers(TblIotUsers tblIotUsers)
        {
            _context.TblIotUsers.Add(tblIotUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblIotUsers", new { id = tblIotUsers.IotId }, tblIotUsers);
        }

        // DELETE: api/TblIotUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblIotUsers(int id)
        {
            var tblIotUsers = await _context.TblIotUsers.FindAsync(id);
            if (tblIotUsers == null)
            {
                return NotFound();
            }

            _context.TblIotUsers.Remove(tblIotUsers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblIotUsersExists(int id)
        {
            return _context.TblIotUsers.Any(e => e.IotId == id);
        }
    }
}
