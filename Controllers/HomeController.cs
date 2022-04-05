using Microsoft.AspNetCore.Mvc;
using Projektarbete_ASP.NET.Models;
using System.Diagnostics;

namespace Projektarbete_ASP.NET.Controllers
{
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
}