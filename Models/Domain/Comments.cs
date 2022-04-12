namespace Projektarbete_ASP.NET.Models.Domain;

public class Comments
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Comment { get; set; }
    public Movie Movie { get; set; }
}
