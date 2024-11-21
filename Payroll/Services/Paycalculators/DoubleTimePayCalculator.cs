using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services.Paycalculators;

public class DoubleTimePayCalculator : IPayCalculator
{
    public decimal CalculatePay(ITimecardRecord timecard, decimal effectiveRate)
    {
        return timecard.Hours * effectiveRate * 2.0m + timecard.Bonus;
    }
}