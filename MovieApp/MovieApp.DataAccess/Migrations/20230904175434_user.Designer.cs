﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.DataAccess;

#nullable disable

namespace MovieApp.DataAccess.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20230904175434_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieApp.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bames returns for one last mission to save the president from impending doom.",
                            Genre = 2,
                            Title = "Bames Jond 2",
                            Year = 1970
                        },
                        new
                        {
                            Id = 2,
                            Description = "Wellsa was a failed cryogenic scientist, destined to unfreeze people that have been frozen.",
                            Genre = 4,
                            Title = "Unfrozen",
                            Year = 2020
                        },
                        new
                        {
                            Id = 3,
                            Description = "Aliens are invading Earth and it's up to a group of unlikely heroes to stop them.",
                            Genre = 4,
                            Title = "Space Invaders",
                            Year = 2019
                        },
                        new
                        {
                            Id = 4,
                            Description = "A group of explorers venture into the jungle searching for a lost city of gold.",
                            Genre = 6,
                            Title = "Jungle Adventure",
                            Year = 2015
                        },
                        new
                        {
                            Id = 5,
                            Description = "A family moves into a new house only to find out that it is haunted.",
                            Genre = 5,
                            Title = "Mystery of the Haunted House",
                            Year = 2010
                        },
                        new
                        {
                            Id = 6,
                            Description = "A lone warrior fights against the forces of evil.",
                            Genre = 2,
                            Title = "The Last Warrior",
                            Year = 2005
                        },
                        new
                        {
                            Id = 7,
                            Description = "Friends go on a road trip and have a series of comedic adventures.",
                            Genre = 1,
                            Title = "Road Trip",
                            Year = 2018
                        },
                        new
                        {
                            Id = 8,
                            Description = "A romantic story set in the city of love, Paris.",
                            Genre = 3,
                            Title = "Love in Paris",
                            Year = 2016
                        },
                        new
                        {
                            Id = 9,
                            Description = "A team of treasure hunters go on an expedition to find a hidden treasure.",
                            Genre = 6,
                            Title = "Treasure Hunt",
                            Year = 2022
                        },
                        new
                        {
                            Id = 10,
                            Description = "In a future where AI has taken over, a group of rebels fight to take back control.",
                            Genre = 4,
                            Title = "Tech Apocalypse",
                            Year = 2030
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieApp.Domain.Models.Movie", b =>
                {
                    b.HasOne("MovieApp.Domain.Models.User", null)
                        .WithMany("MovieList")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MovieApp.Domain.Models.User", b =>
                {
                    b.Navigation("MovieList");
                });
#pragma warning restore 612, 618
        }
    }
}