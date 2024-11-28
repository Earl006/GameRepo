using System;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext>options) 
    :DbContext(options) 
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // First create Genre entity
    modelBuilder.Entity<Genre>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).IsRequired();
    });

    // Then seed data
    modelBuilder.Entity<Genre>().HasData(
        new Genre { Id = 1, Name = "Action" },
        new Genre { Id = 2, Name = "RPG" },
        new Genre { Id = 3, Name = "Adventure" },
        new Genre { Id = 4, Name = "Horror" },
        new Genre { Id = 5, Name = "Simulation" }
    );
}
}
