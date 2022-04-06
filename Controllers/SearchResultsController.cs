using Microsoft.AspNetCore.Mvc;
using Projektarbete_ASP.NET.Data;

namespace Projektarbete_ASP.NET.Controllers;
public class SearchResultsController : Controller
{
    public SearchResultsController(ApplicationDbContext context)
    {
        Context = context;
    }

    public ApplicationDbContext Context { get; }

    [Route("/search")]
    public IActionResult Index([FromQuery] string q)
    {
        var movies = Context.Movie.Where(x => x.Title.Contains(q)).ToList();

        ViewData["SearchWord"] = q;

        return View(movies);
    }
}
