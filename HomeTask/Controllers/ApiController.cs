using HomeTask.Data;
using HomeTask.Models;
using HomeTask.MyServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly CalculationHistoryService _calculationHistoryService;

        public ApiController(AppDbContext context)
        {
            _context = context;
            _operatorService = new OperatorLogic(_context); 
            _calculationHistoryService = new CalculationHistoryService(_context);
        }

        [HttpGet("operators")]
        public async Task<ActionResult<List<Operator>>> GetAllOperators()
        {
            var operators = await _context.Operators.ToListAsync();
            return Ok(operators);
        }

        [HttpPost("calculate")]
        public async Task<ActionResult<CalculationResult>> Calculate([FromBody] CalculateRequest request)
        {
            try
            {
                Console.WriteLine($"Received: ValueA={request.ValueA}, ValueB={request.ValueB}, Operation={request.Operation}");

                var result = _operatorService.Calculate(request.ValueA, request.ValueB, request.Operation);

                
                var historyAction = new HistoryActions
                {
                    ValueA = request.ValueA,
                    ValueB = request.ValueB,
                    Operation = request.Operation,
                    Result = result,
                    Timestamp = DateTime.UtcNow 
                };

                _context.HistoryActions.Add(historyAction);
                Console.WriteLine($"Saving HistoryActions: ValueA={historyAction.ValueA}, ValueB={historyAction.ValueB}, Operation={historyAction.Operation}, Result={historyAction.Result}");

                await _context.SaveChangesAsync();

                
                var lastActions = await _calculationHistoryService.GetLastActionsAsync(request.Operation);
                var usageCount = await _calculationHistoryService.GetUsageCountAsync(request.Operation);

                return Ok(new CalculationResult
                {
                    Result = result,
                    LastActions = lastActions,
                    UsageCount = usageCount
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred during calculation.");
            }
        }
    }
}
