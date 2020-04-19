using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        /// <summary>
        /// This will run asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

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
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}