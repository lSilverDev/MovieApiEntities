using Microsoft.EntityFrameworkCore;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Session> Session { get; set; }
    }
}
