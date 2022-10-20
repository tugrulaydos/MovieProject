﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ContextMovieDB : IdentityDbContext<User, UserRole, int>
    {
        //public ContextMovieDB(DbContextOptions<ContextMovieDB> dbContext) : base(dbContext) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D80M3PV; database=MovieDB1; integrated security=true;");

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<FilmCategory>()
        //        .HasKey(fc => new {fc.})
        //}


        public DbSet<Comment> Comments { get; set; }       

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Film> Films { get; set; }       

        public DbSet<Watched> Watcheds { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }
    }
}
