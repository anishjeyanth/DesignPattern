using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface ICustomer
    {
        string Name { get; set; }
        abstract String getName();
    }

    public class RealCustomer : ICustomer
    {
       public RealCustomer(string name)
       {
            Name = name;
       }

       public string Name { get ; set ; }

       public string getName()
       {
            return Name;
       }
    }

    public class NullCustomer : ICustomer
    {

        public string Name { get; set; } = "None";

        public string getName()
        {
            return Name;
        }
    }

    public class CustomerFactory
    {
        public static string[] names = {"Rob", "Joe", "Julie"};
        public static ICustomer getCustomer(string name)
        {

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Contains(name))
                {
                    return new RealCustomer(name);
                }
            }

            return new NullCustomer();
        }
    }


    internal class NullObject
    {
        public NullObject()
        {
            ICustomer customer1 = CustomerFactory.getCustomer("Rob");
            ICustomer customer2 = CustomerFactory.getCustomer("Bob");
            Console.WriteLine(customer1.getName());
            Console.WriteLine(customer2.getName());
        }
    }
}
