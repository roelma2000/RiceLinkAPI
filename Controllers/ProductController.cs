using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiceLinkAPI.Models.Products;
using System;

namespace RiceLinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new List<Product>()
        {
            new Product {
                Id = 201,
                Name = "Organic Brown Rice",
                Origin = "USA",
                PackageSize = "5kg",
                Price = 18.99M,
                Currency = "CAD",
                InStock = true,
                Description = "Whole grain brown rice, rich in natural fibers and minerals."
            },
            new Product {
                Id = 202,
                Name = "Black Rice",
                Origin = "China",
                PackageSize = "2kg",
                Price = 22.5M,
                Currency = "CAD",
                InStock = false,
                Description = "Nutrient-dense black rice, known for its antioxidant properties."
            }
        };

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Product not found");
            return Ok(product);
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<Product>>> SearchProductsByName(string name)
        {
            var matchingProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!matchingProducts.Any())
                return NotFound("No products found with the given name.");

            return Ok(matchingProducts);
        }




        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
                return BadRequest("Product not found");

            product.Name = request.Name;
            product.Origin = request.Origin;
            product.PackageSize = request.PackageSize;
            product.Price = request.Price;
            product.Currency = request.Currency;
            product.InStock = request.InStock;
            product.Description = request.Description;
            product.InStock = request.InStock;


            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Product not found");
            products.Remove(product);
            return Ok(product);
        }

    }
}
