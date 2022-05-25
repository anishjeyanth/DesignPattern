namespace DesignPattern.Pattern
{
    public abstract class Pizza
    {
        public virtual string description { get; protected set; } = "Unknown Beverage";
        public abstract int getCost();
    }

    public abstract class ToppingsDecorator : Pizza
    {
        public abstract override string description { get; }
    }

    public class PeppyPaneer : Pizza
    {
        public PeppyPaneer() 
        { 
           description = "PeppyPaneer"; 
        }

        public override int getCost() 
        { 
            return 100; 
        }
    }

    public class Margherita : Pizza
    {
        public Margherita() 
        { 
            description = "Margherita"; 
        }

        public override int getCost() 
        { 
            return 200; 
        }
    }

    public class FreshTomato : ToppingsDecorator
    {
        private Pizza pizza;
        public FreshTomato(Pizza pizza)
        {
            this.pizza = pizza; 
        }
        public override string description => pizza.description + ", FreshTomato";
        public override int getCost() 
        { 
            return 40 + pizza.getCost();
        }
    }
    public class Barbeque : ToppingsDecorator
    {
        private Pizza pizza;
        public Barbeque(Pizza pizza) 
        { 
            this.pizza = pizza; 
        }
        public override string description => pizza.description + ", Barbeque";

        public override int getCost() 
        { 
            return 90 + pizza.getCost(); 
        }
    }


    internal class Decorator
    {
        public Decorator()
        {
            Pizza pizza = new Margherita();
            Console.WriteLine($"{pizza.description},{pizza.getCost()}");

            Pizza pizza1 = new PeppyPaneer();
            pizza1 = new FreshTomato(pizza1);
            pizza1 = new Barbeque(pizza1);
            Console.WriteLine($"{pizza1.description},{pizza1.getCost()}");
        }
    }

    /*
        Pizza acts as our abstract component class.
        There are four concrete components namely PeppyPaneer , FarmHouse, Margherita, ChickenFiesta.
        ToppingsDecorator is our abstract decorator and FreshTomato , Paneer, Jalapeno, Barbeque are concrete decorators.
    */
}
