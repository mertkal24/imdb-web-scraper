using System;
using System.Collections.Generic;
using System.Text;
using Imdb.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Imdb.DataAccessLayer.Context
{

   public class ImdbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5E1JL7B; Initial Catalog=WinImdb; Integrated Security=SSPI;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CastOfMovie>().HasKey(x => new { x.MovieID, x.CastID, x.RoleID });
        }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CastOfMovie> CastOfMovies { get; set; }

    }
}
