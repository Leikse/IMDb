using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projektarbete_ASP.NET.Data;
using Projektarbete_ASP.NET.Models.Domain;
using Projektarbete_ASP.NET.Models.ViewModels;

namespace Projektarbete_ASP.NET.Controllers;

public class MoviesController : Controller
{
    public MoviesController(ApplicationDbContext context)
    {
        Context = context;
    }

    private ApplicationDbContext Context { get; }

    [Route("Movies/{urlSlug}")]
    public IActionResult Details(string urlSlug)
    {
        var comments = Context.Comments
            .Include(x => x.Movie)
            .Where(x => x.Movie.UrlSlug == urlSlug)
            .ToList();

        Movie movie = Context.Movie.FirstOrDefault(movie => movie.UrlSlug == urlSlug);

        var viewModel = new MovieIndexViewModel
        {
            Comments = comments,
            Movie = movie,
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Movies/{urlSlug}")]
    public async Task<IActionResult> Details(MovieIndexViewModel viewModel, string urlSlug)
    {
        if (viewModel.Comment.Length > 1)
        {
            var movie = Context.Movie
                .Where(x => x.UrlSlug == urlSlug).FirstOrDefault();

            var comment = new Comments
            {
                Comment = viewModel.Comment,
                Name = User.Identity.Name,
                Movie = movie
            };

            Context.Comments.Add(comment);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        return View();
    }
}
