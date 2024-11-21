using Microsoft.AspNetCore.Mvc;
using TechnicalInterviewDayforce.Services.Interfaces;

namespace TechnicalInterviewDayforce.Controllers;

public class PayrollController : Controller
{
    private readonly IPayrollService _payrollService;
    private readonly IPayrollRepository _payrollRepository;

    public PayrollController(
        IPayrollService payrollService,
        IPayrollRepository payrollRepository)
    {
        _payrollService = payrollService;
        _payrollRepository = payrollRepository;
    }

    public IActionResult Index()
    {
        var timeCards = _payrollRepository.GetTimeCards();
        var rateTable = _payrollRepository.GetRateTable();
        var result = _payrollService.SummarizePayRecord(timeCards, rateTable);

        _payrollRepository.UpdatePaySummaries(result);

        return View(result);
    }
}