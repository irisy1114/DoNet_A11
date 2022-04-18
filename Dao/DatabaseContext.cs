using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary.Dao
{
    public class DatabaseContext : IContext
    {
        public void AddMovie()
        {
            Console.Write("\nPlease enter the new Movie title: ");
            var movieTitle = Console.ReadLine();

            Console.Write("Enter the release date of the movie(M/dd/yyyy): ");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            // create new movie
            var movie = new Movie();
            movie.Title = movieTitle;
            movie.ReleaseDate = releaseDate;

            // save movie object to database
            using (var context = new MovieContext())
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }
            
            Console.WriteLine("The new movie has been added.");
        }

        public void SearchMovie()
        {
            Console.Write("\nEnter the search string to search movies(enter 'star' to test): ");
            var searchString = Console.ReadLine().ToLower();
            using (var context = new MovieContext())
            {
                var results = context.Movies.Where(x => x.Title.Contains(searchString)).ToList();
                Console.WriteLine("Your results are: ");
                foreach (var movie in results)
                {
                    Console.WriteLine($"{movie.Id} {movie.Title} {movie.ReleaseDate}");
                }

                //results.ForEach(Console.WriteLine);
            }
        }

        public void UpdateMovie()
        {
            // can try "Lightning Jack (1994)" the last record to update, it's case sensitive
            Console.Write("\nEnter Movie Title to Update: ");
            var movieTitle = Console.ReadLine();

            Console.Write("Enter Updated Movie Title: ");
            var updatedTitle = Console.ReadLine();

            using (var context = new MovieContext())
            {
                var updateMovie = context.Movies.FirstOrDefault(x => x.Title == movieTitle);
                Console.WriteLine($"({updateMovie.Id}) {updateMovie.Title} {updateMovie.ReleaseDate}");

                updateMovie.Title = updatedTitle;

                context.Movies.Update(updateMovie);
                context.SaveChanges();
            }

            Console.WriteLine("The movie has been updated.");
        }

        public void DeleteMovie()
        {
            Console.Write("\nEnter Movie Title to Delete: ");
            var title = Console.ReadLine();

            using (var context = new MovieContext())
            {
                var deleteMovie = context.Movies.FirstOrDefault(x => x.Title == title);
                Console.WriteLine($"({deleteMovie.Id}) {deleteMovie.Title} {deleteMovie.ReleaseDate}");

                // verify exists first
                context.Movies.Remove(deleteMovie);
                context.SaveChanges();
            }

            Console.WriteLine("The movie has been deleted.");
        }
    }
}
