namespace Projektarbete_ASP.NET.Models.Domain;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Uri ImageUrl { get; set; }
    public Uri VideoUrl { get; set; }
    public string Genre { get; set; }
    public string Plot { get; set; }
    public decimal Rating { get; set; }
    public int ReleaseYear { get; set; }
    public string? UrlSlug { get; set; }
}

