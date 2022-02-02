using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Game_Genre>()
                .HasOne(g => g.Game)
                .WithMany(gg => gg.Game_Genres)
                .HasForeignKey(gi=>gi.GameId);

            modelBuilder.Entity<Game_Genre>()
                .HasOne(g => g.Genre)
                .WithMany(gg => gg.Game_Genres)
                .HasForeignKey(gi => gi.GenreId);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game_Genre> Game_Genre { get; set; }
    }
}
