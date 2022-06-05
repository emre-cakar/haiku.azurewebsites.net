using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using haiku_mvc.Models;

namespace haiku_mvc.Controllers;

public class LoginController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

}
