using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

namespace MongoDbAPI.Controllers   
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();
        //esta accion nos permite acceder a esto desde afuera
        [HttpGet]
        
         public async Task<IActionResult> GetAllProducts()
         {
             return Ok(await db.GetAllProducts());
         }

         [HttpGet("{id}")]
         public async Task<IActionResult> GetAllProductsDetails(string id)
         {
             return Ok(await db.GetProductById(id));
         }

         [HttpPost]        
         public async Task<IActionResult> CreateProduct([FromBody] Product product)
         {
            if (product == null)
                return BadRequest("El producto no puede ser nulo");

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El producto no debe estar vacío.");
            }

            await db.InsertProduct(product);

            return Created("Created", true);
         }

         [HttpPut("{id}")]        
         public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
         {
            if (product == null)
                return BadRequest("El producto no puede ser nulo");

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "El producto no debe estar vacío.");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);

            await db.UpdateProduct(product);

            return Created("Created", true);
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);

            return NoContent();
        }

    }
}