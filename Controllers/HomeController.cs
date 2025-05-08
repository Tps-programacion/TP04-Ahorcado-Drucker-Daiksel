using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Drcuker_Daiksel.Models;

namespace TP04_Drcuker_Daiksel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
