namespace DesignPattern.Pattern
{
    public interface IEmployee
    {
        public void Info();
    }

    public class Employee : IEmployee
    {
        private string name { get; set; }
        public Employee(string name)
        {
            this.name = name;
        }

        public void Info()
        {
            Console.WriteLine(name);
        }
    }

    public class CompositeEmployee : IEmployee
    {
        private List<IEmployee> accounts;
        private string department { get; set; }

        public CompositeEmployee(string department)
        {
            this.department = department;   
            accounts = new List<IEmployee>();
        }
        public void Add(IEmployee amount)
        {
            accounts.Add(amount);
        }

        public void Info()
        {
            Console.WriteLine(department);
            foreach(IEmployee account in accounts)
            {
               account.Info();
            }
        }
    }

    internal class Composite
    {
        public Composite()
        {
            CompositeEmployee compositeEmployee = new CompositeEmployee("Math");
            compositeEmployee.Add(new Employee("a"));
            compositeEmployee.Add(new Employee("b"));
            compositeEmployee.Add(new Employee("c"));
            compositeEmployee.Info();

            CompositeEmployee compositeEmployee1 = new CompositeEmployee("Science");
            compositeEmployee1.Add(new Employee("ty"));
            compositeEmployee1.Add(new Employee("hj"));
            compositeEmployee1.Add(new Employee("nm"));
            compositeEmployee1.Info();

        }
    }
}
