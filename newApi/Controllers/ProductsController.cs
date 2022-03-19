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
    public class ProductsController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;

        public ProductsController(dbSmartAgricultureContext context)
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

        [HttpGet("GetSeedProduct")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetSeedProduct()
        {
            
            var Result= await _context.TblProduct.Where(s => s.CategoryId == 1).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Result;
            

        }

        [HttpGet("GetToolProduct")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetToolProduct()
        {

            var Result = await _context.TblProduct.Where(s => s.CategoryId == 2).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Result;


        }

        [HttpGet("GetFerProduct")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetFerProduct()
        {

            var Result = await _context.TblProduct.Where(s => s.CategoryId ==3).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Result;


        }
    }
}
