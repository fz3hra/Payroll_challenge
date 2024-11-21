using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Home/Index accessed");
        try 
        {
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Home/Index");
            return Content($"Error: {ex.Message}");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}