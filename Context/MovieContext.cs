using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieLibrary.DataModels;

namespace MovieLibrary.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<MovieGenre> MovieGenres {get;set;}
        public DbSet<Occupation> Occupations {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserMovie> UserMovies {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("MovieContext"));

            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=bitsql.wctc.edu;Database=mmcarthey_12090_Movie;User ID=mmcarthey;Password=000075813;");
        }
    }
}