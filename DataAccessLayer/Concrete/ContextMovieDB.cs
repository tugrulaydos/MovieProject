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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Artist--Film
            modelBuilder.Entity<ArtistFilm>()
                .HasKey(af => new { af.ArtistID, af.FilmID });

            modelBuilder.Entity<ArtistFilm>()
                .HasOne(af => af.Artist)
                .WithMany(a => a.Films)
                .HasForeignKey(af => af.ArtistID);

            modelBuilder.Entity<ArtistFilm>()
                .HasOne(af => af.Film)
                .WithMany(f => f.Artists)
                .HasForeignKey(af => af.FilmID);


            //Category--Film
            modelBuilder.Entity<CategoryFilm>()
                .HasKey(cf => new { cf.CategoryID, cf.FilmID });

            modelBuilder.Entity<CategoryFilm>()
                .HasOne(cf => cf.Category)
                .WithMany(c => c.Films)
                .HasForeignKey(cf => cf.CategoryID);

            modelBuilder.Entity<CategoryFilm>()
                .HasOne(cf => cf.Film)
                .WithMany(f => f.Categories)
                .HasForeignKey(cf => cf.FilmID);




        }


        public DbSet<Comment> Comments { get; set; }       

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Film> Films { get; set; }       

        public DbSet<Watched> Watcheds { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

        public DbSet<CategoryFilm> CategoryFilms { get; set; }

        public DbSet<ArtistFilm> ArtistFilms { get; set; }

      

       
    }
}
