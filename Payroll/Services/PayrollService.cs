using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services;

public class PayrollService : IPayrollService
{
    private readonly IRateTableService _rateTableService;
    private readonly PayCalculatorFactory _payCalculatorFactory;

    public PayrollService(
        IRateTableService rateTableService,
        PayCalculatorFactory payCalculatorFactory)
    {
        _rateTableService = rateTableService;
        _payCalculatorFactory = payCalculatorFactory;
    }
    
    private PaySummaryRecord CreatePaySummary(
            IGrouping<dynamic, ITimecardRecord> group, 
            IEnumerable<IRateTableRow> rateTable)
    {
            decimal totalPay = 0;
            decimal totalHours = 0;

            foreach (var timecard in group)
            {
                var effectiveRate = _rateTableService.GetHighestestRate(timecard, rateTable);
                var calculator = _payCalculatorFactory.GetCalculator(timecard.EarningsCode);
            
                totalPay += calculator.CalculatePay(timecard, effectiveRate);
                totalHours += timecard.Hours;
            }

            return new PaySummaryRecord
            {
                EmployeeName = group.Key.EmployeeName,
                EmployeeNumber = group.Key.EmployeeNumber,
                Job = group.Key.JobWorked,
                Dept = group.Key.DeptWorked,
                TotalHours = totalHours,
                TotalPayAmount = totalPay,
                RateOfPay = totalPay / totalHours,
                EarningsCode = string.Join(",", group.Select(g => g.EarningsCode).Distinct())
            };
    }

    public List<PaySummaryRecord> SummarizePayRecord(IEnumerable<ITimecardRecord> TimeCard, IEnumerable<IRateTableRow> RateTable)
    {
        List<PaySummaryRecord> PaySummaryRecords = new List<PaySummaryRecord>();
        decimal Rate = 0;
        
        decimal RateOfPay = 0;
        decimal effectiveRate = 0;
        decimal payCode = 0;
        
        /*
         * summarize employee hours and dollar. amounts
         * from their timecard
         *
         * 1. for each empployee, calculate
         * - rate if dept and job rate matches with rate table then, and if
         * - rate is higher either from rate table or timecard, depending,
         * - use that...
         * -
         *
         */

        var employees = TimeCard.GroupBy(t => new
        {
            t.EmployeeNumber,
            t.EmployeeName,
            t.JobWorked,
            t.DeptWorked
        });
        var payrollSummaries = new List<PaySummaryRecord>();
        
        foreach (var employee in employees)
        {
            var summary = CreatePaySummary(employee, RateTable);
            payrollSummaries.Add(summary);
        }

        return payrollSummaries;
    }
}