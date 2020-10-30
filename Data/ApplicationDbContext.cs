using System;
using System.Collections.Generic;
using System.Text;
using Lab24_Bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab24_Bookstore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<CheckedOutMovies> CheckedOutMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(i =>
            {
                i.HasKey(k => k.Id);
                i.HasData(
                    new Movie { Id = 1, Title = "Jumanji: Welcome to the Jungle", Genre = "Comedy", Runtime = 119},
                    new Movie { Id = 2, Title = "Jumanji: The Next Level", Genre = "Comedy", Runtime = 123 },
                    new Movie { Id = 3, Title = "Spider-Man: Homecoming", Genre = "Action", Runtime = 133 },
                    new Movie { Id = 4, Title = "John Wick: Chapter 3", Genre = "Action", Runtime = 130 },
                    new Movie { Id = 5, Title = "Venom", Genre = "Action", Runtime = 112 },
                    new Movie { Id = 6, Title = "Logan", Genre = "Action", Runtime = 141 },
                    new Movie { Id = 7, Title = "The Grudge", Genre = "Horror", Runtime = 94 },
                    new Movie { Id = 8, Title = "It: Chapter Two", Genre = "Horror", Runtime = 170 },
                    new Movie { Id = 9, Title = "The Conjuring", Genre = "Horror", Runtime = 112 },
                    new Movie { Id = 10, Title = "Knives Out", Genre = "Mystery", Runtime = 130 },
                    new Movie { Id = 11, Title = "Murder on the Orient Express", Genre = "Mystery", Runtime = 114 },
                    new Movie { Id = 12, Title = "The Social Dilemma", Genre = "Documentary", Runtime = 94 },
                    new Movie { Id = 13, Title = "The Fight", Genre = "Documentary", Runtime = 97 },
                    new Movie { Id = 14, Title = "The Greated Showman", Genre = "Musical", Runtime = 106 },
                    new Movie { Id = 15, Title = "Rocketman", Genre = "Musical", Runtime = 122 }
                    );
                i.Property(m => m.Title).HasMaxLength(50);
                i.Property(m => m.Genre).HasMaxLength(50);
            });

            /*
            modelBuilder.Entity<CheckedOutMovies>(i =>
            {
                i.HasKey(k => k.Id);
                i.HasMany(m => Movie).WithOne(m => m.CheckedOutMovie).HasForeignKey(k => k.Id);
                //i.HasOne(m => m.User).WithMany(m => m.Chec);
            });
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}
