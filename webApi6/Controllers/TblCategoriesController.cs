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
    public class TblCategoriesController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblCategoriesController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategory>>> GetTblCategory()
        {
            return await _context.TblCategory.ToListAsync();
        }

        // GET: api/TblCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCategory>> GetTblCategory(int id)
        {
            var tblCategory = await _context.TblCategory.FindAsync(id);

            if (tblCategory == null)
            {
                return NotFound();
            }

            return tblCategory;
        }

        // PUT: api/TblCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCategory(int id, TblCategory tblCategory)
        {
            if (id != tblCategory.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(tblCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCategoryExists(id))
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

        // POST: api/TblCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCategory>> PostTblCategory(TblCategory tblCategory)
        {
            _context.TblCategory.Add(tblCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCategory", new { id = tblCategory.CategoryId }, tblCategory);
        }

        // DELETE: api/TblCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCategory(int id)
        {
            var tblCategory = await _context.TblCategory.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            _context.TblCategory.Remove(tblCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCategoryExists(int id)
        {
            return _context.TblCategory.Any(e => e.CategoryId == id);
        }
    }
}
