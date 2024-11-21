namespace TechnicalInterviewDayforce.Models;

public class RateTableRow : IRateTableRow
{
    public string Job {get; set;}
    public string Dept {get; set;}
    public DateTime EffectiveStart {get; set;}
    public DateTime EffectiveEnd {get; set;}
    public decimal HourlyRate {get; set;}
}