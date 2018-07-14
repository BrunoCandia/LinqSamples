using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public class Movie
    {
        public string Title { get; set; }

        public float Rating { get; set; }
        
        //public int Year { get; set; }

        int year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returning {year} of {Title}");
                return year;
            }
            set
            {
                year = value;
            }
        }
    }
}
