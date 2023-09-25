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
    [Route("api/order")]
    public class CaptureOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CaptureOrdersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] CaptureOrdersModel model)
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

                _dbContext.CaptureOrders?.Add(model);
                await _dbContext.SaveChangesAsync();

                return Ok("Product captured successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("Products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _dbContext.CaptureOrders?.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                _dbContext.CaptureOrders?.Remove(product);
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
