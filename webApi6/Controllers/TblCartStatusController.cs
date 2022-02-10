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
    public class TblCartStatusController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblCartStatusController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblCartStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCartStatus>>> GetTblCartStatus()
        {
            return await _context.TblCartStatus.ToListAsync();
        }

        // GET: api/TblCartStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCartStatus>> GetTblCartStatus(int id)
        {
            var tblCartStatus = await _context.TblCartStatus.FindAsync(id);

            if (tblCartStatus == null)
            {
                return NotFound();
            }

            return tblCartStatus;
        }

        // PUT: api/TblCartStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCartStatus(int id, TblCartStatus tblCartStatus)
        {
            if (id != tblCartStatus.CartStatusId)
            {
                return BadRequest();
            }

            _context.Entry(tblCartStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCartStatusExists(id))
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

        // POST: api/TblCartStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCartStatus>> PostTblCartStatus(TblCartStatus tblCartStatus)
        {
            _context.TblCartStatus.Add(tblCartStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCartStatus", new { id = tblCartStatus.CartStatusId }, tblCartStatus);
        }

        // DELETE: api/TblCartStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCartStatus(int id)
        {
            var tblCartStatus = await _context.TblCartStatus.FindAsync(id);
            if (tblCartStatus == null)
            {
                return NotFound();
            }

            _context.TblCartStatus.Remove(tblCartStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCartStatusExists(int id)
        {
            return _context.TblCartStatus.Any(e => e.CartStatusId == id);
        }
    }
}
