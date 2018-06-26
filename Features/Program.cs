using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers2 = new Employee[]
            {
                new Employee { Id = 1, Name = "Juan" },
                new Employee { Id = 2, Name = "Jose" }
            };

            // Otra forma de hacer foreach
            IEnumerator<Employee> enumeratorDevelopers2 = developers2.GetEnumerator();
            while (enumeratorDevelopers2.MoveNext())
            {
                Console.WriteLine(enumeratorDevelopers2.Current.Name);
            }

            foreach (var person in developers2)
            {
                Console.WriteLine(person.Name);
            }

            IEnumerable<Employee> sales2 = new List<Employee>
            {
                new Employee { Id = 3, Name = "Pedro" },
                new Employee { Id = 4, Name = "Pablo" }
            };

            // Otra forma de hacer foreach
            IEnumerator<Employee> enumeratorSales2 = sales2.GetEnumerator();
            while (enumeratorSales2.MoveNext())
            {
                Console.WriteLine(enumeratorSales2.Current.Name);
            }

            // Una forma de llamar al extension method
            Console.WriteLine(MyLinq.Count(sales2));

            // Otra forma de llamar al extension method
            Console.WriteLine(sales2.Count());

            foreach (var person in sales2)
            {
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("**********");
            /*******************************************/

            Employee[] developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Juan" },
                new Employee { Id = 2, Name = "Jose" }
            };

            foreach (var person in developers)
            {
                Console.WriteLine(person.Name);
            }

            List<Employee> sales = new List<Employee>
            {
                new Employee { Id = 3, Name = "Pedro" },
                new Employee { Id = 4, Name = "Pablo" }
            };                       

            foreach (var person in sales)
            {
                Console.WriteLine(person.Name);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
