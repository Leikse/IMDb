using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projektarbete_ASP.NET.Models.Domain;

namespace Projektarbete_ASP.NET.Models.ViewModels;

public class CreateMovieViewModel
{
    public string Title { get; set; }

    [Display(Name = "Release Year")]
    public int ReleaseYear { get; set; }
    public string Plot { get; set; }
    public List<SelectListItem>? GenreList { get; set; }
    public string Genre { get; set; }

    [Display(Name = "Cover Image")]
    public Uri ImageUrl { get; set; }

    [Display(Name = "Trailer")]
    public Uri VideoUrl { get; set; }
    public decimal Rating { get; set; }
}
