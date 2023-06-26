using Microsoft.EntityFrameworkCore;
using moviesAPI___Entities.Models;

namespace moviesAPI___Entities.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.MovieTheaterId });

            modelBuilder.Entity<Session>()
                .HasOne(session => session.MovieTheater)
                .WithMany(movieTheater => movieTheater.Sessions)
                .HasForeignKey(session => session.MovieTheaterId);

            modelBuilder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheater { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Session> Session { get; set; }
    }
}
