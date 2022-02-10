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
    public class TblProductsController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblProductsController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProduct()
        {
            return await _context.TblProduct.ToListAsync();
        }

        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProduct>> GetTblProduct(int id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);

            if (tblProduct == null)
            {
                return NotFound();
            }

            return tblProduct;
        }

        // PUT: api/TblProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProduct(int id, TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(tblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductExists(id))
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

        // POST: api/TblProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProduct>> PostTblProduct(TblProduct tblProduct)
        {
            _context.TblProduct.Add(tblProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProduct", new { id = tblProduct.ProductId }, tblProduct);
        }

        // DELETE: api/TblProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProduct(int id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            _context.TblProduct.Remove(tblProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductExists(int id)
        {
            return _context.TblProduct.Any(e => e.ProductId == id);
        }
    }
}
