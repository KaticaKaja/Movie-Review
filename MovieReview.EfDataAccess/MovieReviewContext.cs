using Microsoft.EntityFrameworkCore;
using MovieReview.Domain;
using MovieReview.EfDataAccess.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.EfDataAccess
{
    public class MovieReviewContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // konfiguracije, zabrana prikazivanja obrisanih entiteta
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new ActorMovieConfiguration());

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Movie>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Review>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(u => !u.IsDeleted);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=movie-review;Integrated Security=True");
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
    }
}
