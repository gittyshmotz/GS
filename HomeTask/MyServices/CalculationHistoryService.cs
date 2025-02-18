using HomeTask.Data;
using HomeTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.MyServices
{
    public class CalculationHistoryService
    {
        private readonly AppDbContext _context;

        public CalculationHistoryService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<HistoryActions>> GetLastActionsAsync(string operation, int count = 3)
        {
            try
            {
                if (string.IsNullOrEmpty(operation))
                {
                    throw new ArgumentException("Operation cannot be null or empty.", nameof(operation));
                }

                return await _context.HistoryActions
                    .Where(h => h.Operation == operation)
                    .OrderByDescending(h => h.Id) 
                    .Take(count)
                    .Select(h => new HistoryActions
                    {
                        Id = h.Id,
                        Operation = h.Operation,
                        Result = h.Result, 
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while fetching actions.", ex);
            }
        }
        
        public async Task<int> GetUsageCountAsync(string operation)
        {
            var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
            return await _context.HistoryActions
                .CountAsync(h => h.Operation == operation && h.Timestamp >= oneMonthAgo); 
        }
    }
}
