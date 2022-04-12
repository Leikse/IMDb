using Projektarbete_ASP.NET.Models.Domain;

namespace Projektarbete_ASP.NET.Models.ViewModels;

public class MovieIndexViewModel
{
    public Movie? Movie { get; set; }
    public IEnumerable<Comments> Comments { get; set; } = new List<Comments>();
    public string Comment { get; set; }
}
