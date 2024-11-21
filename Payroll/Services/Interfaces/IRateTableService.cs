using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Services.Interfaces;

public interface IRateTableService
{
    decimal GetHighestestRate(ITimecardRecord timecard, IEnumerable<IRateTableRow> rateTable);
}