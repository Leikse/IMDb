using Microsoft.AspNetCore.Mvc;
using Projektarbete_ASP.NET.Data;
using Projektarbete_ASP.NET.Models.ViewModels;

namespace Projektarbete_ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            Context = context;
        }

        private ApplicationDbContext Context { get; }


        public IActionResult Index()
        {
            var movies = Context.Movie.ToList();

            var viewModel = new HomeIndexViewModel
            {
                TopPicks = movies
            };

            return View(viewModel);
        }
    }
}