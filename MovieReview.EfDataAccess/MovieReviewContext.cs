using Microsoft.EntityFrameworkCore;
using MovieReview.Domain;
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

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            //modelBuilder.Entity<>().HasQueryFilter(p => !p.IsDeleted);
            //modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
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
