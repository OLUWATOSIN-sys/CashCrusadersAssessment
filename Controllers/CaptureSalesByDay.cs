using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cashcrusaderspos.Data;
using cashcrusaderspos.Models;

namespace cashcrusaderspos.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class CaptureSalesByDayController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CaptureSalesByDayController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit([FromBody] CaptureSalesByDayModel model)
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

                _dbContext.CaptureSalesByDay?.Add(model);
                await _dbContext.SaveChangesAsync();

                return Ok("Sales by day captured successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("TotalSalesCount")]
        public IActionResult GetTotalSalesCount()
        {
            try
            {
                
                var totalSalesCount = _dbContext.CaptureSalesByDay?.Count();

                return Ok(totalSalesCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "An error occurred while fetching total sales count.");
            }
        }
    }
}
