namespace TechnicalInterviewDayforce.Models;

public interface ITimecardRecord
{
    public string EmployeeName { get; set; }
    public string EmployeeNumber { get; set; }
    public DateTime DateWorked { get; set; }
    public string EarningsCode { get; set; }
    public string JobWorked { get; set; }
    public string DeptWorked { get; set; }
    public decimal Hours { get; set; }
    public decimal Rate { get; set; }
    public decimal Bonus { get; set; }
}