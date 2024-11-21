using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Services.Interfaces;

public interface IPayrollService
{
    List<PaySummaryRecord> SummarizePayRecord(
        IEnumerable<ITimecardRecord> timeCards, 
        IEnumerable<IRateTableRow> rateTable);
}