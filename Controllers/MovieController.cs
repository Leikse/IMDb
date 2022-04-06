using Microsoft.AspNetCore.Mvc;
using Projektarbete_ASP.NET.Data;
using Projektarbete_ASP.NET.Models.Domain;
using Projektarbete_ASP.NET.Models.ViewModels;

namespace Projektarbete_ASP.NET.Controllers;

public class MovieController : Controller
{
    public MovieController(ApplicationDbContext context)
    {
        Context = context;
    }

    private ApplicationDbContext Context { get; }

    [Route("Movies/{urlSlug}")]
    public IActionResult Details(string urlSlug)
    {
        Movie movie = Context.Movie.FirstOrDefault(movie => movie.UrlSlug == urlSlug);

        var viewModel = new MovieIndexViewModel
        {
            Movie = movie,
        };

        return View(viewModel);
    }
}
