using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Services.Interfaces;

public interface IPayCalculator
{
    decimal CalculatePay(ITimecardRecord timecard, decimal effectiveRate);
}