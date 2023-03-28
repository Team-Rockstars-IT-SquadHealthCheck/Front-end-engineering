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

    public async Task<IActionResult> Index()
    {
        HttpClient httpClient = new();
        string httpResponseMessage = await httpClient.GetStringAsync("http://40.113.119.8:80/HelloWorld");
        Console.WriteLine(httpResponseMessage);
        ViewData["httpResponseMessage"] = httpResponseMessage;
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Form(FormSubmissionModel model)
    {
        if (!ModelState.IsValid)
        {
            string validation = "Je moet alles invullen!";
            ViewData["validationMessage"] = validation;
            return View(model);
        }
        return RedirectToAction(nameof(BedanktScherm));
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