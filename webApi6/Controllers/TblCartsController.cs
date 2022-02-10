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
    public class TblCartsController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblCartsController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCart>>> GetTblCart()
        {
            return await _context.TblCart.ToListAsync();
        }

        // GET: api/TblCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCart>> GetTblCart(int id)
        {
            var tblCart = await _context.TblCart.FindAsync(id);

            if (tblCart == null)
            {
                return NotFound();
            }

            return tblCart;
        }

        // PUT: api/TblCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCart(int id, TblCart tblCart)
        {
            if (id != tblCart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(tblCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCartExists(id))
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

        // POST: api/TblCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCart>> PostTblCart(TblCart tblCart)
        {
            _context.TblCart.Add(tblCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCart", new { id = tblCart.CartId }, tblCart);
        }

        // DELETE: api/TblCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCart(int id)
        {
            var tblCart = await _context.TblCart.FindAsync(id);
            if (tblCart == null)
            {
                return NotFound();
            }

            _context.TblCart.Remove(tblCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCartExists(int id)
        {
            return _context.TblCart.Any(e => e.CartId == id);
        }
    }
}
