using HomeTask.Data;
using HomeTask.Models;
using HomeTask.MyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeTask.Controllers
{
    [ApiController]
    [Route("api")] 
    public class ApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OperatorLogic _operatorService;

        public ApiController(AppDbContext context)
        {
            _context = context;
            _operatorService = new OperatorLogic();
        }

        [HttpGet("operators")]
        public async Task<ActionResult<List<Operator>>> GetAllOperators()
        {
            var operators = await _context.Operators.ToListAsync();
            return Ok(operators);
        }

        [HttpPost("calculate")]
        public ActionResult<double> Calculate([FromBody] CalculateRequest request)
        {
            try
            {
                Console.WriteLine($"Received: ValueA={request.ValueA}, ValueB={request.ValueB}, Operation={request.Operation}");

                var result = _operatorService.Calculate(request.ValueA, request.ValueB, request.Operation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

       

    }
}
