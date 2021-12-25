using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface IStaff
    {
        public void AssignTask(string task);
    }

    public class Developer : IStaff
    {
        string task = string.Empty;
        public void AssignTask(string task)
        {
            this.task = task;
        }

        public void display()
        {
            Console.WriteLine(task);
        }
    }

    public class Tester : IStaff
    {
        string task = string.Empty;
        public void AssignTask(string task)
        {
            this.task = task;
        }

        public void display()
        {
            Console.WriteLine(task);
        }
    }

    public class StaffFactory
    {
        private static Dictionary<string, IStaff> staff = new Dictionary<string, IStaff>();

        public static IStaff GetStaff(string type)
        {
            IStaff staf = null;
            var sta = staff.FirstOrDefault(x => x.Key == type);
            staf = sta.Value;
            if (staf == null)
            {
                switch (type)
                {
                    case "developer":
                        Developer developer = new Developer();
                        developer.AssignTask("to develop");
                        staff.Add("developer", developer);
                        Console.WriteLine("developer created");
                        staf = developer;
                        break;
                    case "tester":
                        Tester tester = new Tester();
                        tester.AssignTask("to test");
                        staff.Add("tester", tester);
                        Console.WriteLine("tester created");
                        staf = tester;
                        break;
                }
            }

            return staf;
        }
    }

    public class Office
    {
        public void show()
        {
            for (int i = 0; i <= 10; i++)
            {
                IStaff deve = StaffFactory.GetStaff("developer");
                Developer st = (Developer)deve;
                st.display();

                IStaff tester = StaffFactory.GetStaff("tester");
                Tester st1 = (Tester)tester;
                st1.display();
            }
        }
    }

    internal class Flyweight
    {
        public Flyweight()
        {
            new Office().show();
        }
    }
}
