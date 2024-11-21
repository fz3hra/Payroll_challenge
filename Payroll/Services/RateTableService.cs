using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services;

public class RateTableService : IRateTableService
{
    public decimal GetHighestestRate(ITimecardRecord timecard, IEnumerable<IRateTableRow> rateTable)
    {
        var rate = rateTable
            .Where(r => 
                r.Job == timecard.JobWorked && 
                r.Dept == timecard.DeptWorked &&
                timecard.DateWorked >= r.EffectiveStart &&
                timecard.DateWorked <= r.EffectiveEnd)
            .OrderByDescending(r => r.EffectiveStart)
            .FirstOrDefault();

        return rate != null ? Math.Max(timecard.Rate, rate.HourlyRate) : timecard.Rate;
    }
}