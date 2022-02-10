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
    public class TblMembersController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblMembersController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMembers>>> GetTblMembers()
        {
            return await _context.TblMembers.ToListAsync();
        }

        // GET: api/TblMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMembers>> GetTblMembers(int id)
        {
            var tblMembers = await _context.TblMembers.FindAsync(id);

            if (tblMembers == null)
            {
                return NotFound();
            }

            return tblMembers;
        }

        // PUT: api/TblMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMembers(int id, TblMembers tblMembers)
        {
            if (id != tblMembers.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(tblMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMembersExists(id))
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

        // POST: api/TblMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMembers>> PostTblMembers([FromBody]TblMembers tblMembers)
        {
            
            _context.TblMembers.Add(tblMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMembers", new { id = tblMembers.MemberId }, tblMembers);
        }

        // DELETE: api/TblMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMembers(int id)
        {
            var tblMembers = await _context.TblMembers.FindAsync(id);
            if (tblMembers == null)
            {
                return NotFound();
            }

            _context.TblMembers.Remove(tblMembers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblMembersExists(int id)
        {
            return _context.TblMembers.Any(e => e.MemberId == id);
        }
    }
}
