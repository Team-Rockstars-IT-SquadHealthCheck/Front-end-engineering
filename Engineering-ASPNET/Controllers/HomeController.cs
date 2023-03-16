using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Engineering_ASPNET.Models;
using Microsoft.Extensions.Logging;
using System.Collections;
using System;

namespace Engineering_ASPNET.Controllers;

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

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Form(FormSubmissionModel model)
    {

        if (ModelState.IsValid)
        {
            return RedirectToAction(nameof(BedanktScherm));
            
        }
        
        return View();
    }
    public IActionResult BedanktScherm()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}