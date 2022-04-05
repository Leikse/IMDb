using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projektarbete_ASP.NET.Models.Domain;

namespace Projektarbete_ASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movie { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
