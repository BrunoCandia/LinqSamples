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
            #region Region7 - Streaming opeartors

            Console.WriteLine("Streaming opeartors");

            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region6 - Non-streaming operator (OrderBy)
            /*
                Operator that offer deferred execition also can be devided into
                streaming operator(Where) and non-streaming operator(OrderBy)
            */

            Console.WriteLine("Non-streaming operator (OrderBy)");

            var movies6 = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query6 = movies6.Where(m => m.Year > 2000)
                                .OrderByDescending(m => m.Rating);

            var enumerator3 = query6.GetEnumerator();
            while (enumerator3.MoveNext())
            {
                Console.WriteLine(enumerator3.Current.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region5 - Streaming operator (Where)
            /*
                Operator that offer deferred execition also can be devided into
                streaming operator(Where) and non-streaming operator(OrderBy)
            */

            Console.WriteLine("Streaming operator (Where)");

            var movies5 = new List<Movie> {
                new Movie { Title = "the dark", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "the king", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "star wars", Rating = 8.7f, Year = 1980 }
            };

            var query5 = movies5.Where(m => m.Year > 2000);

            var enumerator2 = query5.GetEnumerator();
            while (enumerator2.MoveNext())
            {
                Console.WriteLine(enumerator2.Current.Title);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

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
