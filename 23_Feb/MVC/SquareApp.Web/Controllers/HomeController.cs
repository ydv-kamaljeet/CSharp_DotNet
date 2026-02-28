using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SquareApp.Web.Models;

namespace SquareApp.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult square()
    {
        int number = 5*5;
        return Content(number.ToString());
    }
    public IActionResult Divide()
    {
        int a =5;
        int b =0;
        int c =a/b;
        return Content(c.ToString());
    }

    public IActionResult Error()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
