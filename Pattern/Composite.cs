using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IEmployee
    {
        public void Balance();
    }

    public class Employee : IEmployee
    {
        private int amount { get; set; }
        public Employee(int amount)
        {
            this.amount = amount;
        }

        public void Balance()
        {
            Console.WriteLine(amount);
        }
    }

    public class CompositeEmployee : IEmployee
    {
        private List<IEmployee> accounts;

        public CompositeEmployee()
        {
            accounts = new List<IEmployee>();
        }
        public void Add(IEmployee amount)
        {
            accounts.Add(amount);
        }

        public void Balance()
        {
            foreach(IEmployee account in accounts)
            {
               account.Balance();
            }
        }
    }

    internal class Composite
    {
        public Composite()
        {
            CompositeEmployee compositeEmployee = new CompositeEmployee();
            compositeEmployee.Add(new Employee(100));
            compositeEmployee.Add(new Employee(300));
            compositeEmployee.Add(new Employee(700));
            compositeEmployee.Balance();

            CompositeEmployee compositeEmployee1 = new CompositeEmployee();
            compositeEmployee1.Add(new Employee(110));
            compositeEmployee1.Add(new Employee(310));
            compositeEmployee1.Add(new Employee(710));
            compositeEmployee1.Balance();

        }
    }
}
