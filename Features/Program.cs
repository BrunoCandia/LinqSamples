using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Region5 - Method syntax and Query syntax

            Employee[] developers4 = new Employee[]
            {
                new Employee { Id = 1, Name = "Juan" },
                new Employee { Id = 2, Name = "Jose" },
                new Employee { Id = 3, Name = "Antonio" }
            };

            var query = developers4.Where(e => e.Name.Length == 7)
                                   .OrderBy(e => e.Name);
                                   //.Select(e => e.Name);    // The Select is optional in this case

            foreach (var person in query)
            {
                Console.WriteLine("METHOD SYNTAX");
                Console.WriteLine(person.Name);
            }

            var query2 = from developer in developers4
                         where developer.Name.Length == 7
                         orderby developer.Name
                         select developer;

            foreach (var person in query2)
            {
                Console.WriteLine("QUERY SYNTAX");
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region4 Action - Takes 0 or more parameters and returns void

            Func<int, int> square2 = x => x * x;
            Action<int> write = x => Console.WriteLine(x);

            Console.WriteLine("ACTION");
            write(square2(3));

            #endregion

            /*******************************************/

            #region Region4 Func - Takes 0 or more parameters and returns a value

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> add2 = (x, y) => 
            {
                int temp = x + y;
                return temp;
            };

            Console.WriteLine("LAMBDA EXPRESSION");
            Console.WriteLine(square(3));
            Console.WriteLine(square(add(3, 5)));

            // On the left hand side of the lambda we have the parameters list (in this case "x")
            // On the right hand side of the lambda we have the expression that returns a value (in this case "x * x")
            Func<int, int> f1 = x => x * x;

            Func<int, int> f = Square;

            Console.WriteLine("NAME METHOD");
            Console.WriteLine(f(3));

            Console.WriteLine("**********");
            Console.WriteLine("\r");
            //Console.WriteLine("\r\n");

            #endregion

            /*******************************************/

            #region Region3

            Employee[] developers3 = new Employee[]
            {
                new Employee { Id = 1, Name = "Juan" },
                new Employee { Id = 2, Name = "Jose" },
                new Employee { Id = 3, Name = "Carlos" }
            };

            foreach (var person in developers3.Where(e => e.Name.StartsWith("C")))
            {
                Console.WriteLine("LAMBDA EXPRESSION");
                Console.WriteLine(person.Name);
            }

            foreach (var person in developers3.Where(
                delegate (Employee employee)
                {
                    Console.WriteLine("ANONYMOUS METHOD");
                    return employee.Name.StartsWith("C");
                }))
            {
                Console.WriteLine(person.Name);
            }

            foreach (var person in developers3.Where(NameStartsWithC))
            {
                Console.WriteLine("NAME METHOD");
                Console.WriteLine(person.Name);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region2

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
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region1

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

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static int Square(int arg)
        {
            return arg * arg;
        }

        private static bool NameStartsWithC(Employee employee)
        {
            return employee.Name.StartsWith("C");
        }
    }
}
