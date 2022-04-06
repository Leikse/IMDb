using Projektarbete_ASP.NET.Models.Domain;

namespace Projektarbete_ASP.NET.Models.ViewModels;

public class HomeIndexViewModel
{
    public Movie Movie { get; set; }
    public IEnumerable<Movie> TopPicks { get; set; } = new List<Movie>();
}
