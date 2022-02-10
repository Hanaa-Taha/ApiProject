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
    public class TblSlideImagesController : ControllerBase
    {
        private readonly DbsmartagricultureContext _context;

        public TblSlideImagesController(DbsmartagricultureContext context)
        {
            _context = context;
        }

        // GET: api/TblSlideImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSlideImage>>> GetTblSlideImage()
        {
            return await _context.TblSlideImage.ToListAsync();
        }

        // GET: api/TblSlideImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSlideImage>> GetTblSlideImage(int id)
        {
            var tblSlideImage = await _context.TblSlideImage.FindAsync(id);

            if (tblSlideImage == null)
            {
                return NotFound();
            }

            return tblSlideImage;
        }

        // PUT: api/TblSlideImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSlideImage(int id, TblSlideImage tblSlideImage)
        {
            if (id != tblSlideImage.SlideId)
            {
                return BadRequest();
            }

            _context.Entry(tblSlideImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSlideImageExists(id))
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

        // POST: api/TblSlideImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSlideImage>> PostTblSlideImage(TblSlideImage tblSlideImage)
        {
            _context.TblSlideImage.Add(tblSlideImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSlideImage", new { id = tblSlideImage.SlideId }, tblSlideImage);
        }

        // DELETE: api/TblSlideImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSlideImage(int id)
        {
            var tblSlideImage = await _context.TblSlideImage.FindAsync(id);
            if (tblSlideImage == null)
            {
                return NotFound();
            }

            _context.TblSlideImage.Remove(tblSlideImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSlideImageExists(int id)
        {
            return _context.TblSlideImage.Any(e => e.SlideId == id);
        }
    }
}
