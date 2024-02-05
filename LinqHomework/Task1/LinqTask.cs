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
            var resultList = customers.Min(customer => customer.Orders);
            resultList.Join(suppliers,)
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            var resultList = customers.Select(customer =>
           new
           {
               Customer = customer,
               firstOrderDate = customer.Orders.Min(order => order.OrderDate)
           }
       )
           .OrderBy(record => record.firstOrderDate.Year)
                .ThenByDescending(record => record.firstOrderDate.Month)
                .OrderBy(record => record.Customer.CompanyName).ToList();
            return (IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)>)resultList;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            var resultList = customers.Where(customer => !customer.PostalCode.All(char.IsDigit) || customer.Region == "undefined" || customer.PostalCode.All(c=>c!='('&&c!=')'));
            return resultList;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
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

            var resultList = products.GroupBy(product => product.Category).Select(productGroup => new
            {
                Category = productGroup.Key,
                UnitsInStock = productGroup.GroupBy(p => p.UnitsInStock)
                 .Select(inStockGroup => new
                          {
                            unitInStock = inStockGroup.Key,
                            Products = inStockGroup.OrderBy(p => p.UnitPrice)
                            })
            });
            return (IEnumerable<Linq7CategoryGroup>)resultList;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            var productList = products.GroupBy(product =>
            {
                if (0 <= product.UnitPrice && product.UnitPrice <= cheap)
                {
                    return cheap;
                }
                else if (cheap < product.UnitPrice && product.UnitPrice <= middle)
                {
                    return middle;
                }
                else
                {
                    return expensive;
                }
            })
                .Select(group => (category: group.Key, products: group));
            return (IEnumerable<(decimal category, IEnumerable<Product> products)>)productList;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            var resultList = customers.GroupBy(c => c.City)
                                        .Select(cityGroup => (
                                        city: cityGroup.Key,
                                        averageIncome: (int)cityGroup.Average(c => c.Orders.Average(l=>l.Total)
                                        )));
            return (IEnumerable<(string city, int averageIncome, int averageIntensity)>)resultList;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            var resultList = suppliers.Select(supplier => supplier.Country).Distinct().OrderBy(s => s.Length).ThenBy(s => s);
            string result = string.Join(",", resultList);
            return result;
        }
    }
}