using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ContextMovieDB : IdentityDbContext<User, UserRole, int>
    {
        

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer("Server=DESKTOP-D80M3PV; database=MovieDB; integrated security=true;");

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<FilmCategory>()
        //        .HasKey(fc => new { fc.CategoryID, fc.FilmID });

        //    modelBuilder.Entity<FilmArtist>()
        //        .HasKey(fa => new { fa.FilmID, fa.ArtistID });         

        //}


        public DbSet<Comment> Comments { get; set; }       

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Film> Films { get; set; }       

        public DbSet<Watched> Watcheds { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

       
    }
}
