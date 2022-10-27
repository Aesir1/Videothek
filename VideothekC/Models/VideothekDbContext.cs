using Microsoft.EntityFrameworkCore;

namespace VideothekC.Models;

public class VideothekDbContext : DbContext
{
    public VideothekDbContext(DbContextOptions<VideothekDbContext> options)
        : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerViewedFilm> CustomerViewedFilms { get; set; }
}