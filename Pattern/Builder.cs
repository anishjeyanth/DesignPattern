namespace DesignPattern.Pattern
{
    //Builder
    public interface IVehicle
    {
        void BuildEngine();
        void BuildBody();
        Product GetVehicle();
    }

    //Concrete Builder
    public class Car : IVehicle
    {
        private Product product;
        public Car()
        {
            product = new Product();
        }
        public void BuildBody()
        {
            product.Add("Car body built");
        }

        public void BuildEngine()
        {
            product.Add("Car engine built");
        }

        public Product GetVehicle()
        {
            return product;
        }
    }

    //Product
    public class Product
    {
        private List<string> parts;
        public Product()
        {
            parts = new List<string>();
        }

        public void Add(string action)
        {
            parts.Add(action);
        }

        public void Show()
        {
            foreach (string item in parts)
            {
                Console.WriteLine(item);
            }
        }
    }

    //Director
    public class Director
    {
        private IVehicle vehicle;
        public void Construct(IVehicle vehicle)
        {
            this.vehicle = vehicle;
            this.vehicle.BuildBody();
            this.vehicle.BuildEngine();
        }
    }

    internal class Builder
    {
        public Builder() 
        {
            Director director = new Director();
            IVehicle vehicle = new Car();
            director.Construct(vehicle);
            Product product = vehicle.GetVehicle();
            product.Show();
        }
    }
}

/*
 Product is the complex object under consideration. ConcreteBuilder
constructs and assembles the parts of a Product object by implementing an abstract
interface called Builder. The ConcreteBuilder objects builds the internal representations
of the products and defines the creation process and assembly mechanisms. Director is
responsible for creating the final object using the Builder interface.
*/