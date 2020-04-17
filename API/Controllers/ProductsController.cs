using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        /// <summary>
        /// This will run asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }
        /// <summary>
        /// synchronous request - not good approach.
        /// Will wait until _context.Products will be done.
        /// </summary>
        /// <returns></returns>
        // public ActionResult<List<Product>> GetProducts()
        // {
        //     var products = _context.Products.ToList();

        //     return Ok(products);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
               return await _context.Products.FindAsync(id);
        }
    }
}