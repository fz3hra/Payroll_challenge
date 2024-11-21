namespace TechnicalInterviewDayforce.Models;

public class PaySummaryRecord
{
    public string EmployeeName {get; set;}
    public string EmployeeNumber {get; set;}
    public string EarningsCode {get; set;}
    public decimal TotalHours {get; set;}
    public decimal TotalPayAmount {get; set;}
    public decimal RateOfPay {get; set;  }
    public string Job {get; set; }
    public string Dept {get; set;}
}