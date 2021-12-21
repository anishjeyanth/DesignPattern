using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public class Vehicle
    {
        public string Engine {  get; set; }
        public int Wheel { get; set; }
        public int Accessories { get; set; }

        private Vehicle(VehicleBuilder builder)
        {
            Engine = builder.engine;    
            Wheel = builder.wheel;
            Accessories = builder.accessories;
        }

        public class VehicleBuilder
        {
            public string engine { get; private set; }
            public int wheel { get; private set; }
            public int accessories { get; private set; }
            public VehicleBuilder(string engine)
            {
                this.engine = engine;
            }

            public VehicleBuilder SetEngine(int wheel)
            {
                this.wheel = wheel;
                return this;
            }

            public VehicleBuilder SetAccessories(int accessories)
            {
                this.accessories = accessories;
                return this;
            }

            public Vehicle Build()
            {
                return new Vehicle(this);
            }
        }
    }
    
    internal class Builder1
    {
        public Builder1()
        {
            Vehicle veh = new Vehicle.VehicleBuilder("BMW").SetEngine(1).SetAccessories(4).Build();
            Console.WriteLine($"{veh.Engine},{veh.Wheel},{veh.Accessories}");
        }
    }
}


