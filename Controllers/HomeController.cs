using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{

    [HttpGet("")]
    public IActionResult Index()
    {
      int? Generation = HttpContext.Session.GetInt32("PasscodeGen");
      if (Generation == null) {
        HttpContext.Session.SetInt32("PasscodeGen", 1);
      }
      else
      {
        Generation += 1;
        HttpContext.Session.SetInt32("PasscodeGen", (int)Generation);
      }

      string PossibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*";
      string Passcode = "";
      Random Rand = new Random();

      for ( int i = 0; i < 14; i++ ) {
        Passcode += PossibleChars[Rand.Next(0, 69)];
      }
      HttpContext.Session.SetString("NewPasscode", Passcode);
      string? NewPasscode = HttpContext.Session.GetString("NewPasscode");

        return View();
    }

    [HttpPost("generate")]
    public IActionResult Generate()
    {
      return RedirectToAction("");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    
}
