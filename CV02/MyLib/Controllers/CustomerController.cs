using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Controllers
{
    class CustomerController
    {

        private static List<Customer> customers = new List<Customer>()
        {
            new Customer(){ Id = 1, Age = 34, IsActive = true, Name = "Jan" },
            new Customer(){ Id = 2, Age = 46, IsActive = false, Name = "Tom" },
            new Customer(){ Id = 3, Age = 36, IsActive = true, Name = "Michala" }
        };

        public string List(int limit)
        {
            StringBuilder result = new StringBuilder();
            foreach (var customer in customers.Take(limit))
            {
                result.AppendLine(customer.Name);
            }
            return result.ToString();
        }

        public string Add(string name, int age, bool isActive)
        {
            int id = customers.Select(x => x.Id).DefaultIfEmpty().Max() + 1;
            var customer = new Customer() { Id = id, Name = name, Age = age, IsActive = isActive };
            customers.Add(customer);
            return customer.Id.ToString();
        }
    }
}
