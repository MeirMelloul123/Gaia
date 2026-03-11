using GaiaApi.Data;
using GaiaApi.Dto;
using GaiaApi.Interface;
using GaiaApi.Models;
using Microsoft.EntityFrameworkCore;
using NCalc;
using System;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Expression = NCalc.Expression;

namespace GaiaApi.Service
{
    public class OperationService : IOperationService
    {
        private readonly GaiaDbContext _context;

        public OperationService(GaiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Operation>?> GetAllOperationTypes()
        {
            var operationTypes = await _context.Operations.ToListAsync();
            return operationTypes ?? new List<Operation>();
        }

        public async Task<CalculationResponse?> Execute(CalculationRequest calculationRequest)
        {
            if (calculationRequest == null)
                return null;
            if (calculationRequest.OperationId <= 0)
                return null;

            var op = await _context.Operations.FindAsync(calculationRequest.OperationId);
            if (op == null || string.IsNullOrWhiteSpace(op.Formula))
            {
                return null;
            }

            string? result;
            try
            {
                result = GetOperationResult(op.Type, op.Formula, calculationRequest);
            }
            catch
            {
                return null;
            }

            var nowUtc = DateTime.UtcNow;
            var historyLog = new OperationHistory
            {
                FirstField = calculationRequest.FisrtField,
                OperationId = calculationRequest.OperationId,
                SecondField = calculationRequest.SecondField,
                Result = result,
                CreateAt = nowUtc
            };

            try
            {
                _context.OperationHistory.Add(historyLog);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            var lastThreeHistory = await _context.OperationHistory
                .Where(l => l.OperationId == calculationRequest.OperationId && l.Id != historyLog.Id)
                .OrderByDescending(l => l.CreateAt)
                .Take(3).Select((x)=>new OperationHistoryResponse()
                {
                    FirstField=x.FirstField,
                    OperatorName= op.Name,
                    SecondField=x.SecondField,
                    Result=x.Result

                })
                .ToListAsync();

            var monthStart = new DateTime(nowUtc.Year, nowUtc.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var monthEnd = monthStart.AddMonths(1);

            var count = await _context.OperationHistory
       .CountAsync(l => l.CreateAt >= monthStart
                        && l.CreateAt < monthEnd
                        && l.Operation != null
                        && l.Operation.Id == op.Id);

            return new CalculationResponse
            {
                Result = result,
                History = lastThreeHistory,
                Count = count
            };
        }

        private string? GetOperationResult(string? type, string formula, CalculationRequest calculationRequest)
        {
            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(formula))
                return null;

                return EvaluateExpression(type, formula, calculationRequest);

        }
        private string? EvaluateExpression(string type,string formula, CalculationRequest req)
        {
            object? a=null;
            object? b= null;
            switch (type)
            {
                case "String":
                    a = !string.IsNullOrEmpty(req.FisrtField) ? req.FisrtField.Replace(",", ".") : null;
                    b = !string.IsNullOrEmpty(req.SecondField) ? req.SecondField.Replace(",", "."):null;
                    break;
                case "Arithmetic":
                    a = Convert.ToDouble(req.FisrtField);
                    b = Convert.ToDouble(req.SecondField);

                    // check b not 0 if i have division in formula

                    var divByBRegex = new Regex(@"/\s*(?:[+\-]?\s*B\b|\(\s*[+\-]?\s*B\s*\))", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                    if (req.SecondField=="0" && divByBRegex.IsMatch(formula))
                    {
                        throw new ArgumentException($"Division by zero is not allowed.");
                    }
                    break;
                default:
                    return null;
            }
            try
            {
                var expr = new Expression(formula, EvaluateOptions.IgnoreCase);
                expr.Parameters["A"] = a;
                expr.Parameters["B"] = b;
                var eval = expr.Evaluate();
                if (eval == null) return null;
                if (eval is double || eval is float || eval is decimal)
                    return Convert.ToString(eval, CultureInfo.InvariantCulture);
                if (eval is bool bv) return bv ? "true" : "false";
                return eval.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}