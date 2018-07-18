using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Region31 - Create element-oriented XML

            Console.WriteLine("Create attribute-oriented XML");

            CreateAttributeOrientedXML();
            QueryXML();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region30 - Create attribute-oriented XML

            Console.WriteLine("Create attribute-oriented XML");

            CreateAttributeOrientedXML();
            //QueryXML();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region29 - Building attribute-oriented XML - Fourth way

            Console.WriteLine("Building attribute-oriented XML - Fourth way");

            BuildingAttributeOrientedXMLFourthWay();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region28 - Building attribute-oriented XML - Third way

            Console.WriteLine("Building attribute-oriented XML - Third way");

            BuildingAttributeOrientedXMLThirdWay();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region27 - Building attribute-oriented XML - Second way

            Console.WriteLine("Building attribute-oriented XML - Second way");

            BuildingAttributeOrientedXMLSecondWay();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region26 - Building attribute-oriented XML

            Console.WriteLine("Building attribute-oriented XML");

            BuildingAttributeOrientedXML();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region25 - Building element-oriented XML

            Console.WriteLine("Building element-oriented XML");

            BuildingElementOrientedXML();

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region24 - Method syntax - GroupJoin data, ordering and iterating inside

            Console.WriteLine("Method syntax - GroupJoin data, ordering and iterating inside");

            var cars24 = ProcessFile("fuel.csv");
            var manufacturers12 = ProcessManufacturers("manufacturers.csv");

            var query20 = manufacturers12.GroupJoin(cars24,
                                                    m => m.Name,
                                                    c => c.Manufacturer,
                                                    (m, g) => new
                                                    {
                                                        Manufacturer = m,
                                                        Cars = g
                                                    })
                                         .OrderBy(m => m.Manufacturer.Name);

            foreach (var group in query20)
            {
                //Console.WriteLine($"{group.Manufacturer.Name}: {group.Manufacturer.Headquarters}");

                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    //Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region23 - Query syntax - GroupJoin data, ordering and iterating inside

            Console.WriteLine("Query syntax - GroupJoin data, ordering and iterating inside");

            var cars23 = ProcessFile("fuel.csv");
            var manufacturers11 = ProcessManufacturers("manufacturers.csv");

            var query19 = from manufacturer in manufacturers11
                          join car in cars23 on manufacturer.Name equals car.Manufacturer
                          into carGroup
                          orderby manufacturer.Name
                          select new
                          {
                              Manufacturer = manufacturer,
                              Cars = carGroup
                          };

            foreach (var group in query19)
            {
                //Console.WriteLine($"{group.Manufacturer.Name}: {group.Manufacturer.Headquarters}");

                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    //Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region22 - Method syntax - Grouping data, ordering and iterating inside

            Console.WriteLine("Method syntax - Grouping data, ordering and iterating inside");

            var cars22 = ProcessFile("fuel.csv");
            var manufacturers10 = ProcessManufacturers("manufacturers.csv");

            var query18 = cars22.GroupBy(c => c.Manufacturer.ToUpper())
                                .OrderBy(g => g.Key);

            foreach (var group in query18)
            {
                //Console.WriteLine(group.Key);

                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    //Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region21 - Query syntax - Grouping data, ordering and iterating inside

            Console.WriteLine("Query syntax - Grouping data, ordering and iterating inside");

            var cars21 = ProcessFile("fuel.csv");
            var manufacturers9 = ProcessManufacturers("manufacturers.csv");

            var query17 = from car in cars21
                          group car by car.Manufacturer.ToUpper() into manufacturer
                          orderby manufacturer.Key
                          select manufacturer;

            foreach (var group in query17)
            {
                //Console.WriteLine(group.Key);

                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    //Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region20 - Query syntax - Grouping data and iterating inside

            Console.WriteLine("Query syntax - Grouping data and iterating inside");

            var cars20 = ProcessFile("fuel.csv");
            var manufacturers8 = ProcessManufacturers("manufacturers.csv");

            var query16 = from car in cars20
                          group car by car.Manufacturer;

            foreach (var group in query16)
            {
                //Console.WriteLine(group.Key);

                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    //Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region19 - Query syntax - Grouping data

            Console.WriteLine("Query syntax - Grouping data");

            var cars19 = ProcessFile("fuel.csv");
            var manufacturers7 = ProcessManufacturers("manufacturers.csv");

            var query15 = from car in cars19
                          group car by car.Manufacturer;

            foreach (var group in query15)
            {
                //Console.WriteLine($"{group.Key} has {group.Count()} cars");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region18 - Method syntax - Joining data with a composite key

            Console.WriteLine("Method syntax - Joining data with a composite key");

            var cars18 = ProcessFile("fuel.csv");
            var manufacturers6 = ProcessManufacturers("manufacturers.csv");

            var query14 = cars18.Join(manufacturers6,
                                      c => new { c.Manufacturer, c.Year },
                                      m => new { Manufacturer = m.Name, m.Year },
                                      (c, m) => new
                                      {
                                          m.Headquarters,
                                          c.Name,
                                          c.Combined
                                      })
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name);

            foreach (var car in query14.Take(10))
            {
                //Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region17 - Query syntax - Joining data with a composite key

            Console.WriteLine("Query syntax - Joining data with a composite key");

            var cars17 = ProcessFile("fuel.csv");
            var manufacturers5 = ProcessManufacturers("manufacturers.csv");

            var query13 = from car in cars17
                          join manufacturer in manufacturers5
                            on new { car.Manufacturer, car.Year }
                            equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                          orderby car.Combined descending, car.Name ascending
                          select new
                          {
                              manufacturer.Headquarters,
                              car.Name,
                              car.Combined
                          };

            foreach (var car in query13.Take(10))
            {
                //Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region16 - Method syntax - Joining data - Third way

            Console.WriteLine("Method syntax - Joining data - Third way");

            var cars16 = ProcessFile("fuel.csv");
            var manufacturers4 = ProcessManufacturers("manufacturers.csv");

            var query12 = cars16.Join(manufacturers4,
                                      c => c.Manufacturer,
                                      m => m.Name,
                                      (c, m) => new
                                      {
                                          Car = c,
                                          Manufacturer = m
                                      })
                                .OrderByDescending(c => c.Car.Combined)
                                .ThenBy(c => c.Car.Name)
                                .Select(c => new
                                {
                                    c.Manufacturer.Headquarters,
                                    c.Car.Name,
                                    c.Car.Combined
                                });

            foreach (var car in query12.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region15 - Method syntax - Joining data - Second way

            Console.WriteLine("Method syntax - Joining data - Second way");

            var cars15 = ProcessFile("fuel.csv");
            var manufacturers3 = ProcessManufacturers("manufacturers.csv");

            var query11 = cars15.Join(manufacturers3,
                                      c => c.Manufacturer,
                                      m => m.Name,
                                      (c, m) => new
                                      {
                                          Car = c,
                                          Manufacturer = m
                                      })
                                .OrderByDescending(c => c.Car.Combined)
                                .ThenBy(c => c.Car.Name);

            foreach (var car in query11.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer.Headquarters} {car.Car.Name}: {car.Car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region14 - Method syntax - Joining data

            Console.WriteLine("Method syntax - Joining data");

            var cars14 = ProcessFile("fuel.csv");
            var manufacturers2 = ProcessManufacturers("manufacturers.csv");

            var query10 = cars14.Join(manufacturers2,
                                      c => c.Manufacturer,
                                      m => m.Name,
                                      (c, m) => new
                                      {
                                          m.Headquarters,
                                          c.Name,
                                          c.Combined
                                      })
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name);

            foreach (var car in query10.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region13 - Query syntax - Joining data

            Console.WriteLine("Query syntax - Joining data");

            var cars13 = ProcessFile("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query9 = from car in cars13
                         join manufacturer in manufacturers
                            on car.Manufacturer equals manufacturer.Name
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             manufacturer.Headquarters,
                             car.Name,
                             car.Combined
                         };

            foreach (var car in query9.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region12 - With SelectMany

            Console.WriteLine("With SelectMany");

            var cars12 = ProcessFile("fuel.csv");

            var query8 = from car in cars12
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             car.Manufacturer,
                             car.Name,
                             car.Combined
                         };

            var result2 = query8.SelectMany(c => c.Name);

            foreach (var character in result2)
            {
                //Console.WriteLine(character);                
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region11 - Without SelectMany

            Console.WriteLine("Without SelectMany");

            var cars11 = ProcessFile("fuel.csv");

            var query7 = from car in cars11
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             car.Manufacturer,
                             car.Name,
                             car.Combined
                         };

            var result = query7.Select(c => c.Name);

            foreach (var name in result)
            {
                foreach (var character in name)
                {
                    //Console.WriteLine(character);
                }
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region10 - Query syntax - Projecting some fields - Second way

            Console.WriteLine("Query syntax - Projecting some fields - Second way");

            var cars10 = ProcessFile("fuel.csv");

            var query6 = from car in cars10
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             car.Manufacturer,
                             car.Name,
                             car.Combined
                         };

            var top5 = query6.First();

            Console.WriteLine($"{top5.Name}: {top5.Combined}");

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region9 - Query syntax - Projecting some fields

            Console.WriteLine("Query syntax - Projecting some fields");

            var cars9 = ProcessFile("fuel.csv");

            var query5 = from car in cars9
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             Manufacturer = car.Manufacturer,
                             Name = car.Name,
                             Combined = car.Combined
                         };

            var top4 = query5.First();

            Console.WriteLine($"{top4.Name}: {top4.Combined}");

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region8 - Method syntax - Projecting some fields

            Console.WriteLine("Method syntax - Projecting some fields");

            var cars8 = ProcessFile("fuel.csv");

            var top3 = cars8.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                              .OrderByDescending(c => c.Combined)
                              .ThenBy(c => c.Name)
                              .Select(c => new
                              {
                                  c.Manufacturer,
                                  c.Name,
                                  c.Combined
                              })
                              .First();

            Console.WriteLine($"{top3.Name}: {top3.Combined}");

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region7 - Method syntax - Filtering with First with parameters

            Console.WriteLine("Method syntax - Filtering with First with parameters");

            var cars7 = ProcessFile("fuel.csv");

            var top2 = cars7.OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name)
                            .Select(c => c)
                            .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            Console.WriteLine($"{top2.Name}: {top2.Combined}");

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region6 - Method syntax - Filtering with First

            Console.WriteLine("Method syntax - Filtering with First");

            var cars6 = ProcessFile("fuel.csv");

            var top = cars6.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                              .OrderByDescending(c => c.Combined)
                              .ThenBy(c => c.Name)
                              .Select(c => c)
                              .First();

            Console.WriteLine($"{top.Name}: {top.Combined}");

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region5 - Method syntax - Filtering with Where

            Console.WriteLine("Method syntax - Filtering with Where");

            var cars5 = ProcessFile("fuel.csv");

            var query4 = cars5.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                              .OrderByDescending(c => c.Combined)
                              .ThenBy(c => c.Name)
                              .Select(c => c);

            foreach (var car in query4.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region4 - Query syntax - Filtering with Where

            Console.WriteLine("Query syntax - Filtering with Where");

            var cars4 = ProcessFile("fuel.csv");

            var query3 = from car in cars4
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select car;

            foreach (var car in query3.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region3 - Query syntax - Find most fuel efficient

            Console.WriteLine("Query syntax - Find most fuel efficient");

            var cars3 = ProcessFile("fuel.csv");

            var query2 = from car in cars3
                         orderby car.Combined descending, car.Name ascending
                         select car;

            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region2 - Method syntax - Find most fuel efficient

            Console.WriteLine("Method syntax - Find most fuel efficient");

            var cars2 = ProcessFile("fuel.csv");

            var query = cars2.OrderByDescending(c => c.Combined)
                             .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            #region Region1 - Code base

            Console.WriteLine("Code base");

            var cars = ProcessFile("fuel.csv");

            foreach (var car in cars)
            {
                //Console.WriteLine(car.Name);
            }

            Console.WriteLine("**********");
            Console.WriteLine("\r");

            #endregion

            /*******************************************/

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        #region Private methods        

        private static void CreateElementOrientedXML()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);
                var manufacturer = new XElement("Manufacturer", record.Manufacturer);

                car.Add(name);
                car.Add(combined);
                car.Add(manufacturer);

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("fuel-createElementOrientedXML.xml");
        }

        private static void QueryXML()
        {
            var document = XDocument.Load("fuel-createAttributeOriented.xml");

            var query = from element in document.Element("Cars")?.Elements("Car") ?? Enumerable.Empty<XElement>()
                        where element.Attribute("Manufacturer")?.Value == "BMW"
                        select element.Attribute("Name").Value;

            //var query = from element in document.Element("Cars").Elements("Car")
            //            where element.Attribute("Manufacturer")?.Value == "BMW"
            //            select element.Attribute("Name").Value;

            //var query = from element in document.Descendants("Car")
            //            where element.Attribute("Manufacturer")?.Value == "BMW"
            //            select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// This is the same code that "BuildingAttributeOrientedXMLFourthWay"
        /// </summary>
        private static void CreateAttributeOrientedXML()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            var elements = from record in records
                           select new XElement("Car",
                                        new XAttribute("Name", record.Name),
                                        new XAttribute("Combined", record.Combined),
                                        new XAttribute("Manufacturer", record.Manufacturer));

            cars.Add(elements);
            document.Add(cars);
            document.Save("fuel-createAttributeOriented.xml");
        }

        private static void BuildingAttributeOrientedXMLFourthWay()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            var elements = from record in records
                           select new XElement("Car",
                                        new XAttribute("Name", record.Name),
                                        new XAttribute("Combined", record.Combined),
                                        new XAttribute("Manufacturer", record.Manufacturer));

            cars.Add(elements);
            document.Add(cars);
            document.Save("fuel-attributeOrientedFourthWay.xml");
        }

        private static void BuildingAttributeOrientedXMLThirdWay()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car",
                                        new XAttribute("Name", record.Name),
                                        new XAttribute("Combined", record.Combined),
                                        new XAttribute("Manufacturer", record.Manufacturer));

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("fuel-attributeOrientedThirdWay.xml");
        }

        private static void BuildingAttributeOrientedXMLSecondWay()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {                
                var name = new XAttribute("Name", record.Name);
                var combined = new XAttribute("Combined", record.Combined);
                var car = new XElement("Car", name, combined);
                
                cars.Add(car);
            }

            document.Add(cars);
            document.Save("fuel-attributeOrientedSecondWay.xml");
        }

        private static void BuildingAttributeOrientedXML()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XAttribute("Name", record.Name);
                var combined = new XAttribute("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("fuel-attributeOriented.xml");
        }

        private static void BuildingElementOrientedXML()
        {
            var records = ProcessFile("fuel.csv");

            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);

                cars.Add(car);
            }

            document.Add(cars);
            document.Save("fuel.xml");            
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                       .Skip(1)
                       .Where(line => line.Length > 1)
                       .Select(line =>
                       {
                           var columns = line.Split(',');

                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])                               
                           };
                       });

            return query.ToList();
        }

        private static List<Car> ProcessFile(string path)
        {
            //Query syntax
            var query = from line in File.ReadAllLines(path).Skip(1)
                        where line.Length > 1
                        select Car.ParseFromCsv(line);

            query.ToList();

            // Inline projection
            File.ReadAllLines(path)
                       .Skip(1)
                       .Where(line => line.Length > 1)
                       .Select(line =>
                        {
                            var columns = line.Split(',');

                            return new Car
                            {
                                Year = int.Parse(columns[0]),
                                Manufacturer = columns[1],
                                Name = columns[2],
                                Displacement = double.Parse(columns[3]),
                                Cylinders = int.Parse(columns[4]),
                                City = int.Parse(columns[5]),
                                Highway = int.Parse(columns[6]),
                                Combined = int.Parse(columns[7])
                            };
                        })
                       .ToList();

            // Method syntax
            File.ReadAllLines(path)
                       .Skip(1)
                       .Where(line => line.Length > 1)
                       .Select(line => Car.ParseFromCsv(line))
                       .ToList();

            // Method syntax
            File.ReadAllLines(path)
                       .Skip(1)
                       .Where(line => line.Length > 1)
                       .ToCar()
                       .ToList();

            // Method syntax
            return File.ReadAllLines(path)
                       .Skip(1)
                       .Where(line => line.Length > 1)
                       .Select(Car.ParseFromCsv)
                       .ToList();
        }

        #endregion
    }
}
