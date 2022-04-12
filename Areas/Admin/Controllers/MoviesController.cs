#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projektarbete_ASP.NET.Data;
using Projektarbete_ASP.NET.Models.Domain;
using Projektarbete_ASP.NET.Models.ViewModels;

namespace Projektarbete_ASP.NET.Areas.Admin.Controllers
{
    [Authorize] //(Roles = "Administrator")
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Admin/Movies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movie
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        // GET: Admin/Movies/Create
        public IActionResult Create()
        {
            var viewModel = new CreateMovieViewModel
            {
                GenreList = new List<SelectListItem>()
            };

            foreach (var genre in _context.Genre.ToList())
            {
                viewModel.GenreList.Add(new SelectListItem{Value = genre.Name, Text = genre.Name});
            }

            return View(viewModel);
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMovieViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = viewModel.Title,
                    ReleaseYear = viewModel.ReleaseYear,
                    Plot = viewModel.Plot,
                    Genre = viewModel.Genre,
                    ImageUrl = viewModel.ImageUrl,
                    VideoUrl = viewModel.VideoUrl,
                    Rating = viewModel.Rating,
                    UrlSlug = viewModel.Title.Replace("-", "").Replace(" ", "-").ToLower()
                };

                _context.Movie.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Movies");
            }
            viewModel = new CreateMovieViewModel
            {
                GenreList = new List<SelectListItem>()
            };

            foreach (var genre in _context.Genre.ToList())
            {
                viewModel.GenreList.Add(new SelectListItem { Value = genre.Name, Text = genre.Name });
            }

            return View(viewModel);
        }

        // GET: Admin/Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Movies");
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
