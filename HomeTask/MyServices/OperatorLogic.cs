using HomeTask.Data;
using HomeTask.Models;
using System;
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
            return _context?.Operators?.ToList() ?? new List<Operator>();
        }

        public float Calculate(string valueA, string valueB, string operation)
        {
            if (string.IsNullOrEmpty(valueA) || string.IsNullOrEmpty(valueB) || string.IsNullOrEmpty(operation))
            {
                throw new ArgumentException("Input values cannot be null or empty.");
            }

            bool isNumA = double.TryParse(valueA, out double numA);
            bool isNumB = double.TryParse(valueB, out double numB);

            switch (operation)
            {
                case "Add":
                    return (isNumA && isNumB) ? (float)(numA + numB) : float.NaN;
                case "Subtract":
                    if (!isNumA || !isNumB) throw new InvalidOperationException("Invalid input format for subtraction.");
                    return (float)(numA - numB);
                case "Multiply":
                    if (!isNumA || !isNumB) throw new InvalidOperationException("Invalid input format for multiplication.");
                    return (float)(numA * numB);
                case "Divide":
                    if (!isNumA || !isNumB) throw new InvalidOperationException("Invalid input format for division.");
                    if (numB == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return (float)(numA / numB);
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }
        }

    }
}