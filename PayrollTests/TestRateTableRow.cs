using TechnicalInterviewDayforce.Models;

namespace PayrollUnitTest;

public class TestRateTableRow : IRateTableRow
{
    public string Job { get; set; }
    public string Dept { get; set; }
    public DateTime EffectiveStart { get; set; }
    public DateTime EffectiveEnd { get; set; }
    public decimal HourlyRate { get; set; }
}