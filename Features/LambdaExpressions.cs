using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public class LambdaExpressions
    {
        public LambdaExpressions()
        {
            string[] cities = new[] { "city1", "city2", "city3", "city4", "city5" };

            // NAME METHOD
            IEnumerable<string> filteredList = cities.Where(StartsWithC);

            // ANONYMOUS METHOD
            IEnumerable<string> filteredList2 = cities.Where(delegate (string s) {
                                                                return s.StartsWith("c");
                                                            });

            // LAMBDA EXPRESSION
            IEnumerable<string> filteredList3 = cities.Where(s => s.StartsWith("c"));
        }

        public bool StartsWithC(string name)
        {
            return name.StartsWith("c");
        }
    }
}
