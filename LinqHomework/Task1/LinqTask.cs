using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            var customerList = customers.Where(customer => customer.Orders.Length > limit);
            return customerList;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.GroupJoin(
                suppliers,
                customer => new { customer.City, customer.Country },
                supplier => new { supplier.City, supplier.Country },
                (customer, matchingSuppliers) => (customer, matchingSuppliers)
            );
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.GroupJoin(
                suppliers,
                customer => new { customer.City, customer.Country },
                supplier => new { supplier.City, supplier.Country },
                (customer, matchingSuppliers) => (customer, matchingSuppliers)
            );
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            var customerList = customers.Where(customer => customer.Orders.Length > limit)
            .OrderBy(customer => customer.Orders.Select(order => order.OrderDate.Year))
                .ThenBy(customer => customer.Orders.Select(order => order.OrderDate.Month))
                .ThenByDescending(customer => customer.Orders.Select(order => order.OrderDate.Date).First())
                .ThenBy(customer => customer.CompanyName);
            return customerList;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            {
                var result = customers.Select(customer =>
                {
                    var dateOfEntry = customer.Orders.OrderBy(order => order.OrderDate)
                        .Select(order => order.OrderDate)
                        .FirstOrDefault();
                    return (customer, dateOfEntry);
                });

                return result;
            }
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var result = customers
                .Where(c => c != null && c.Orders.Any())
                .Select(c => (customer: c, dateOfEntry: c.Orders.Min(o => o.OrderDate)));

            return result;
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {   if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var result = customers
                .Where(c => c != null && c.Orders.Any(o => o.OrderDate.Year == 1997 && o.OrderDate != null))
                .ToList();

            return result;
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            var resultList = products
                .GroupBy(product => product.Category)
                .Select(productGroup => new Linq7CategoryGroup
                {
                    Category = productGroup.Key,
                    UnitsInStockGroup = productGroup
                        .GroupBy(p => p.UnitsInStock)
                        .Select(inStockGroup => new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = inStockGroup.Key,
                            Prices = inStockGroup.Select(p => p.UnitPrice).OrderBy(price => price).ToArray()
                        })
                        .ToArray()
                })
                .ToList();

            return resultList;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            var result = from p in products
                group p by p.Category into g
                select (category: Convert.ToDecimal(g.Key),
                    products: g.ToList());

            return (IEnumerable<(decimal category, IEnumerable<Product> products)>)result;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            var resultList = customers
                .GroupBy(c => c.City)
                .Select(cityGroup => (
                    city: cityGroup.Key,
                    averageIncome: cityGroup.Any() ? (int)cityGroup.Average(c => c.Orders.Any() ? c.Orders.Average(l => l.Total) : 0) : 0,
                    averageIntensity: cityGroup.Sum(c => c.Orders.Count())
                ));

            return resultList;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            var resultList = suppliers.Select(supplier => supplier.Country).Distinct().OrderBy(s => s.Length).ThenBy(s => s);
            string result = string.Join("", resultList);
            return result;
        }
    }
}