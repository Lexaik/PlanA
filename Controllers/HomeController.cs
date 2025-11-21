using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlanA.Models;

namespace PlanA.Controllers;

public class Home_controller : Controller {
    private readonly ILogger<Home_controller> _logger;

    public Home_controller(ILogger<Home_controller> logger) {
        _logger = logger;
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new Error_view_model { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}