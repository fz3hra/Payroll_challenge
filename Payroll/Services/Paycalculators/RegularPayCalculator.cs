using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Services.Paycalculators;

public class RegularPayCalculator : IPayCalculator
{
    public decimal CalculatePay(ITimecardRecord timecard, decimal effectiveRate)
    {
        return timecard.Hours * effectiveRate + timecard.Bonus;
    }
}