using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Enums;
using MovieApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Year)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);
            modelBuilder.Entity<Movie>()
    .HasData(
        new Movie()
        {
            Id = 1,
            Title = "Bames Jond 2",
            Description = "Bames returns for one last mission to save the president from impending doom.",
            Genre = Genre.Action,
            Year = 1970
        },
        new Movie()
        {
            Id = 2,
            Title = "Unfrozen",
            Description = "Wellsa was a failed cryogenic scientist, destined to unfreeze people that have been frozen.",
            Genre = Genre.ScienceFiction,
            Year = 2020
        },
        new Movie()
        {
            Id = 3,
            Title = "Space Invaders",
            Description = "Aliens are invading Earth and it's up to a group of unlikely heroes to stop them.",
            Genre = Genre.ScienceFiction,
            Year = 2019
        },
        new Movie()
        {
            Id = 4,
            Title = "Jungle Adventure",
            Description = "A group of explorers venture into the jungle searching for a lost city of gold.",
            Genre = Genre.Adventure,
            Year = 2015
        },
        new Movie()
        {
            Id = 5,
            Title = "Mystery of the Haunted House",
            Description = "A family moves into a new house only to find out that it is haunted.",
            Genre = Genre.Horror,
            Year = 2010
        },
        new Movie()
        {
            Id = 6,
            Title = "The Last Warrior",
            Description = "A lone warrior fights against the forces of evil.",
            Genre = Genre.Action,
            Year = 2005
        },
        new Movie()
        {
            Id = 7,
            Title = "Road Trip",
            Description = "Friends go on a road trip and have a series of comedic adventures.",
            Genre = Genre.Comedy,
            Year = 2018
        },
        new Movie()
        {
            Id = 8,
            Title = "Love in Paris",
            Description = "A romantic story set in the city of love, Paris.",
            Genre = Genre.Romance,
            Year = 2016
        },
        new Movie()
        {
            Id = 9,
            Title = "Treasure Hunt",
            Description = "A team of treasure hunters go on an expedition to find a hidden treasure.",
            Genre = Genre.Adventure,
            Year = 2022
        },
        new Movie()
        {
            Id = 10,
            Title = "Tech Apocalypse",
            Description = "In a future where AI has taken over, a group of rebels fight to take back control.",
            Genre = Genre.ScienceFiction,
            Year = 2030
        }
    );


        }
    }
}
