using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
using System;
using System.Threading.Tasks;
using cashcrusaderspos.Data;
using cashcrusaderspos.Models;

namespace cashcrusaderspos.Controllers
{
    [ApiController]
    [Route("api/orderline")]
    public class CaptureOrderLinesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CaptureOrderLinesController> _logger; 

        public CaptureOrderLinesController(ApplicationDbContext dbContext, ILogger<CaptureOrderLinesController> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] CaptureOrderLinesModel model)
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

                
                var captureOrderLines = new CaptureOrderLinesModel
                {
                    Product = model.Product,
                    Quantity = model.Quantity
                };

                
                _dbContext.CaptureOrderLines?.Add(captureOrderLines);

                
                await _dbContext.SaveChangesAsync();

                
                _logger.LogInformation("Order line captured successfully");

                
                return Ok(new { Status = "Success", Message = "Order line captured successfully" });
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while processing the request");

                
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
