using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            Exercise9();
            Exercise10();
            Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();




            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var products = DataLoader.LoadProducts();

            var outOfStock = products.Where(p => p.UnitsInStock == 0);
            PrintProductInformation(outOfStock);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var products = DataLoader.LoadProducts();

            var moreThanThree = products.Where(p => p.UnitsInStock > 0).Where(p => p.UnitPrice > 3);
            PrintProductInformation(moreThanThree);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();

            var customerInfoandRegion = customers.Where(c => c.Region == "WA").Select(c => c);
            PrintCustomerInformation(customerInfoandRegion);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var product = DataLoader.LoadProducts();

            var productName = product.Select(c => new { c.ProductName });
            foreach (var item in productName)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");
            var product = DataLoader.LoadProducts();

            var productInfo = product.Select(p => new { p, price = p.UnitPrice * 1.25M });
            
                foreach (var item in productInfo)
                {
                    Console.WriteLine(line, item.p.ProductID, item.p.ProductName, item.p.Category, item.price, item.p.UnitsInStock);
                }
            

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");
            var product = DataLoader.LoadProducts();

            var productNameAndCategory = product.Select(p => new { name = p.ProductName, cat = p.Category });

            foreach (var item in productNameAndCategory)
            {
                Console.WriteLine(line, item.name.ToUpper(), item.cat.ToUpper());
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 5}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("==============================================================================");
            var product = DataLoader.LoadProducts();
            

            var allProductInfoPlusBool = product.Select(p => new { p, ReOrder = p.UnitsInStock < 4 });

            foreach (var item in allProductInfoPlusBool)
            {
                Console.WriteLine(line, item.p.ProductID, item.p.ProductName, item.p.Category, item.p.UnitPrice, item.p.UnitsInStock, item.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5, 5}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("==============================================================================");
            var product = DataLoader.LoadProducts();

            var productInfoAndStockValue = product.Select(p => new {p, StockValue = p.UnitsInStock * p.UnitPrice });

            foreach (var item in productInfoAndStockValue)
            {
                Console.WriteLine(line, item.p.ProductID, item.p.ProductName, item.p.Category, item.p.UnitPrice, item.p.UnitsInStock, item.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var numbers = DataLoader.NumbersA.Where(n => n % 2 == 0);

            foreach (var number in numbers)
            {
               
                Console.WriteLine(number);

            }

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customer = DataLoader.LoadCustomers();

            var cheapCustomer = customer.Where(c => c.Orders.Sum(o => o.Total) < 501 && c.Orders.Any());

            PrintCustomerInformation(cheapCustomer);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var oddThree = DataLoader.NumbersC.Where(o => o % 2 == 1).Take(3);

            foreach (var item in oddThree)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var oddThreeOut = DataLoader.NumbersC.Where(o => o % 2 == 1).Skip(3);

            foreach (var item in oddThreeOut)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = DataLoader.LoadCustomers().Where(c => c.Region == "WA");


            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                
               
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                
                Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", customer.Orders.Last().OrderID, customer.Orders.Last().OrderDate, customer.Orders.Last().Total);
                
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var number = DataLoader.NumbersC.TakeWhile(n => n < 6);

            foreach (var item in number)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var number = DataLoader.NumbersC.SkipWhile(n => n % 3 == 0);

            foreach (var item in number)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var products = DataLoader.LoadProducts();

            var abc = products.OrderBy(p => p.ProductName);

            PrintProductInformation(abc);
            

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = DataLoader.LoadProducts();

            var desOrUnSt = products.OrderByDescending(p => p.UnitsInStock);

            PrintProductInformation(desOrUnSt);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary> 
        static void Exercise18()
        {
            var products = DataLoader.LoadProducts();

            var catUnPHiLo = products.OrderBy(p => p.Category);
            
            catUnPHiLo.OrderByDescending(p => p.UnitPrice);

            PrintProductInformation(catUnPHiLo);

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var numbers = DataLoader.NumbersB.Reverse();

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
           
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category);

            string line = "{0,-5} {1,-35}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");

            foreach (var category in products)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(category.Key);
                foreach (var item in category)
                {
                    Console.WriteLine(item.ProductName);
                }
            }


        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            var q = from c in customers
                    select new
                    {
                        CustomerName = c.CompanyName,
                        Years = from o in c.Orders
                                group o by o.OrderDate.Year into gYear
                                select new
                                {
                                    Year = gYear.Key,
                                    Monts = from o in gYear
                                            group o by o.OrderDate.Month into gMonth
                                            select new
                                            {
                                                Month = gMonth.Key,
                                            }
                                }
                    };

            PrintAllCustomers();
            

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var product = DataLoader.LoadProducts();

            var categories = product.Select(p => p.Category).Distinct();

            foreach (var item in categories)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var product = DataLoader.LoadProducts();

            var product789 = product.TakeWhile(p => p.ProductID == 789);

            foreach (var item in product789)
            {
                Console.WriteLine(item);
            }
            

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var products = DataLoader.LoadProducts();

            var outOfStock = products.Where(p => p.Category.Any(u => p.UnitsInStock <= 0)).Select(e => e.Category).ToList();

            foreach (var item in outOfStock)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var products = DataLoader.LoadProducts();

            var allOfTheStock = products.Where(p => p.Category.Any(u => p.UnitsInStock > 0)).Select(e => e.Category).Distinct().ToList();

            foreach (var item in allOfTheStock)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int oddCounter = 0;

            var oddNumbers = DataLoader.NumbersA.Where(n => n % 2 == 1);

            foreach (var item in oddNumbers)
            {
                oddCounter++;
            }

            Console.WriteLine(oddCounter);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customer = DataLoader.LoadCustomers().Select(c => new {customerID = c.CustomerID, orderCount = c.Orders.Count()});

            foreach (var item in customer)
            {
                Console.WriteLine(item.customerID + ", " + item.orderCount);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category, 
                (key, values) => 
                new
                {
                    Category = key,
                    productCount = values.Count()
                });

            foreach (var item in products)
            {
                Console.WriteLine(item.Category + ", " + item.productCount);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category,
                (key, values) =>
                new
                {
                    Category = key,
                    uInStock = values.Sum(p => p.UnitsInStock)
                });

            foreach (var item in products)
            {
                Console.WriteLine(item.Category + ", " + item.uInStock);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category,
               (key, values) =>
               new
               {
                   Category = key,
                   lowestPriced = values.Min(p => p.UnitPrice)
               });

            foreach (var item in products)
            {
                Console.WriteLine(item.Category + ", " + item.lowestPriced);
            }

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category,
               (key, values) =>
               new
               {
                   Category = key,
                   averagePrice = values.Average(p => p.UnitPrice)
               });

            products = products.OrderBy(a => a.averagePrice).Take(3);

            foreach (var item in products)
            {
                Console.WriteLine(item.Category + ", " + item.averagePrice);
            }
        }
    }
}
