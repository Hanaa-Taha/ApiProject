using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;

        public CategoriesController(dbSmartAgricultureContext context)
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
    }
}
