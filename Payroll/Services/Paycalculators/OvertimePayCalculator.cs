using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services.Paycalculators;

public class OvertimePayCalculator : IPayCalculator
{
    public decimal CalculatePay(ITimecardRecord timecard, decimal effectiveRate)
    {
        return timecard.Hours * effectiveRate * 1.5m + timecard.Bonus;
    }
}