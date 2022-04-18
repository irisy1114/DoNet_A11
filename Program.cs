using System;
using MovieLibrary.Dao;
using MovieLibrary.Services;

namespace MovieLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new DatabaseContext();
            var choice = "";
            do
            {
                Console.WriteLine("\n1). Search Movie");
                Console.WriteLine("2). Add Movie");
                Console.WriteLine("3). Update Movie");
                Console.WriteLine("4). Delete Movie");
                Console.Write("Please enter your selection or q to quit: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dbContext.SearchMovie();
                        break;
                    case "2":
                        dbContext.AddMovie();
                        break;
                    case "3":
                        dbContext.UpdateMovie();
                        break;
                    case "4":
                        dbContext.DeleteMovie();
                        break;
                }
            } while (choice != null && choice != "q");
        }
    }
}
