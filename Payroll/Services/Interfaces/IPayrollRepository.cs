using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Services.Interfaces;

public interface IPayrollRepository
{
    IEnumerable<ITimecardRecord> GetTimeCards();
    IEnumerable<IRateTableRow> GetRateTable();
    void UpdatePaySummaries(IEnumerable<PaySummaryRecord> summaries);
}