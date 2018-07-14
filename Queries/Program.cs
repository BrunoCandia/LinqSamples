using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Region4 - Custom filter operator with deferred execution and GetEnumerator()"

            Console.WriteLine("Custom filter operator with deferred execution and GetEnumerator()");

            var movies4 = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query4 = movies4.FilterWithDeferredExecution(m => m.Year > 2000);

            var enumerator = query4.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region3 - Custom filter operator with deferred execution given by "yield return"

            Console.WriteLine("Custom filter operator with deferred execution given by yield return");

            var movies3 = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query3 = movies3.FilterWithDeferredExecution(m => m.Year > 2000);

            foreach (var movie in query3)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region2 - Custom filter operator

            Console.WriteLine("Custom filter operator");

            var movies2 = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query2 = movies2.Filter(m => m.Year > 2000);

            foreach (var movie in query2)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region1 - Base code

            Console.WriteLine("Base code");

            var movies = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query = movies.Where(m => m.Year > 2000);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion            

            /*******************************************/

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
