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
    public class TblShippingDetailsController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblShippingDetailsController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblShippingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblShippingDetails>>> GetTblShippingDetails()
        {
            return await _context.TblShippingDetails.ToListAsync();
        }

        // GET: api/TblShippingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblShippingDetails>> GetTblShippingDetails(int id)
        {
            var tblShippingDetails = await _context.TblShippingDetails.FindAsync(id);

            if (tblShippingDetails == null)
            {
                return NotFound();
            }

            return tblShippingDetails;
        }

        // PUT: api/TblShippingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblShippingDetails(int id, TblShippingDetails tblShippingDetails)
        {
            if (id != tblShippingDetails.ShippingDetailId)
            {
                return BadRequest();
            }

            _context.Entry(tblShippingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblShippingDetailsExists(id))
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

        // POST: api/TblShippingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblShippingDetails>> PostTblShippingDetails(TblShippingDetails tblShippingDetails)
        {
            _context.TblShippingDetails.Add(tblShippingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblShippingDetails", new { id = tblShippingDetails.ShippingDetailId }, tblShippingDetails);
        }

        // DELETE: api/TblShippingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblShippingDetails(int id)
        {
            var tblShippingDetails = await _context.TblShippingDetails.FindAsync(id);
            if (tblShippingDetails == null)
            {
                return NotFound();
            }

            _context.TblShippingDetails.Remove(tblShippingDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblShippingDetailsExists(int id)
        {
            return _context.TblShippingDetails.Any(e => e.ShippingDetailId == id);
        }
    }
}
