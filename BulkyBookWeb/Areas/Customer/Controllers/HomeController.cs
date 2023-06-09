﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Models;

namespace BulkyBookWeb.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    } // dependency injection [What does it mean?]

    public IActionResult Index() // To pick view, go inside *home* folder, see the file named *Index*
    {
        return View();
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

