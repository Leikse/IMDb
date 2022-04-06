using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Projektarbete_ASP.NET.Areas.Admin.Controllers;

//[Authorize(Roles = "Administrator")]
[Area("Admin")]

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

