using TechnicalInterviewDayforce.Services.Interfaces;
using TechnicalInterviewDayforce.Services.Paycalculators;

namespace TechnicalInterviewDayforce.Services;

public class PayCalculatorFactory
{
    private readonly Dictionary<string, IPayCalculator> _calculators;

    public PayCalculatorFactory()
    {
        _calculators = new Dictionary<string, IPayCalculator>
        {
            { "Regular", new RegularPayCalculator() },
            { "Overtime", new OvertimePayCalculator() },
            { "Double time", new DoubleTimePayCalculator() }
        };
    }

    public IPayCalculator GetCalculator(string earningsCode)
    {
        return _calculators.TryGetValue(earningsCode, out var calculator) 
            ? calculator 
            : _calculators["Regular"];
    }
}