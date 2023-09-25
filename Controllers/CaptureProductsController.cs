using Microsoft.AspNetCore.Mvc;
using cashcrusaderspos.Models;
using cashcrusaderspos.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cashcrusaderspos.Controllers
{
    [ApiController]
    [Route("api/captureproduct")]
    public class CaptureProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CaptureProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] CaptureProductsModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid form data.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dbContext.CaptureProducts?.Add(model);
                await _dbContext.SaveChangesAsync();

                return Ok("Product captured successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("Products")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _dbContext.CaptureProducts?.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while fetching products.");
            }
        }

        [HttpGet("Products/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _dbContext.CaptureProducts?.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while fetching the product.");
            }
        }

        [HttpPut("Products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] CaptureProductsModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Invalid request body.");
                }

                var product = _dbContext.CaptureProducts?.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                _dbContext.SaveChanges();

                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("Products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _dbContext.CaptureProducts?.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                _dbContext.CaptureProducts?.Remove(product);
                _dbContext.SaveChanges();

                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
    }
}
