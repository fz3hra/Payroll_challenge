using TechnicalInterviewDayforce.Models;
using TechnicalInterviewDayforce.Services;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace PayrollUnitTest;

public class PayrollTests
{
    private readonly PayrollService _payrollService;
    private readonly IRateTableService _rateTableService;
    private readonly PayCalculatorFactory _payCalculatorFactory;

    public PayrollTests()
    {
        _rateTableService = new RateTableService();
        _payCalculatorFactory = new PayCalculatorFactory();
        _payrollService = new PayrollService(_rateTableService, _payCalculatorFactory);
    }
    
    [Fact]
    public void Test1()
    {
        var timeCard = new List<ITimecardRecord>()
        {
           new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/1/2023"),
            EarningsCode = "Regular",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        },
        new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/2/2023"),
            EarningsCode = "Regular",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        },
        new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/3/2023"),
            EarningsCode = "Regular",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        },
        new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/4/2023"),
            EarningsCode = "Regular",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        },
        new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/5/2023"),
            EarningsCode = "Regular",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        },
        new TestTimecard()
        {
            EmployeeName = "Kyle James",
            EmployeeNumber = "110011",
            DateWorked = DateTime.Parse("1/6/2023"),
            EarningsCode = "Overtime",
            JobWorked = "Laborer",
            DeptWorked = "001",
            Hours = 8,
            Rate = 15.50m,
            Bonus = 0
        }
        };

        var rateTable = new List<IRateTableRow>()
        {
            new TestRateTableRow()
            {
                Job = "Laborer",
                Dept = "001",
                EffectiveStart = DateTime.Parse("1/1/2023"),
                EffectiveEnd = DateTime.Parse("1/1/2024"),
                HourlyRate = 18.75m
            }
        };

        var result = _payrollService.SummarizePayRecord(timeCard, rateTable);
        Assert.Single(result);
        
        var summary = result[0];
        
        Assert.Equal(48m, summary.TotalHours);
    
        decimal regularPay = 5 * 8 * 18.75m;  // 5 regular days
        decimal overtimePay = 8 * 18.75m * 1.5m;  // 1 overtime day
        decimal expectedTotalPay = regularPay + overtimePay;
    
        Assert.Equal(expectedTotalPay, summary.TotalPayAmount);
    
        decimal expectedRateOfPay = expectedTotalPay / summary.TotalHours;
        Assert.Equal(expectedRateOfPay, summary.RateOfPay);
    
        Assert.Equal("Regular,Overtime", summary.EarningsCode);
    }
}