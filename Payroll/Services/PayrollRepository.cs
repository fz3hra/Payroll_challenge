using TechnicalInterviewDayforce.Configs;
using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services;

/*
 * Deals with the database
 */

public class PayrollRepository : IPayrollRepository
{
    private readonly PayrollDbContext _context;

    public PayrollRepository(PayrollDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ITimecardRecord> GetTimeCards() 
        => _context.Timecards.ToList();

    public IEnumerable<IRateTableRow> GetRateTable() 
        => _context.RateTable.ToList();

    public void UpdatePaySummaries(IEnumerable<PaySummaryRecord> summaries)
    {
        foreach (var summary in summaries)
        {
            var existing = _context.PaySummaries
                .FirstOrDefault(p => 
                    p.EmployeeNumber == summary.EmployeeNumber && 
                    p.Job == summary.Job && 
                    p.Dept == summary.Dept);
            
            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(summary);
            else
                _context.PaySummaries.Add(summary);
        }
        
        _context.SaveChanges();
    }
}