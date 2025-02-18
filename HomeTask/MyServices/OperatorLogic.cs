using HomeTask.Data;
using HomeTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HomeTask.MyServices
{
    public class OperatorLogic
    {
        private readonly AppDbContext _context;

        public OperatorLogic(AppDbContext context)
        {
            _context = context;
        }

        public OperatorLogic()
        {
        }

        public List<Operator> GetOperators()
        {
            
            return _context.Operators.ToList();
        }

        public object Calculate(string valueA, string valueB, string operation)
        {
            
            bool isNumA = double.TryParse(valueA, out double numA);
            bool isNumB = double.TryParse(valueB, out double numB);

            switch (operation)
            {
                case "add":
                    if (isNumA && isNumB)
                    {
                        return numA + numB; 
                    }
                    else
                    {
                        return valueA + valueB; 
                    }
                case "subtract":
                    if (!isNumA || !isNumB)
                        throw new InvalidOperationException("Invalid input format. Please provide valid numbers for subtraction.");
                    return numA - numB;
                case "multiply":
                    if (!isNumA || !isNumB)
                        throw new InvalidOperationException("Invalid input format. Please provide valid numbers for multiplication.");
                    return numA * numB;
                case "divide":
                    if (!isNumB) throw new InvalidOperationException("Invalid input format. Please provide valid numbers for division.");
                    if (numB == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return numA / numB;
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }

        }




    }
}
