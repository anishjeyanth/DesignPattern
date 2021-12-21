using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public abstract class Shapes
    {
        public Shapes()
        {
            this.Draw();
        }
        public abstract void Draw();
    }

    public class Circles : Shapes
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    public class Squares : Shapes
    {
        public override void Draw()
        {
            Console.WriteLine("Square");
        }
    }

    public abstract class Color
    {
        public Color()
        {
            this.Paint();
        }
        public abstract void Paint();
    }

    public class Red : Color
    {
        public override void Paint()
        {
            Console.WriteLine("Red");
        }
    }

    public class Green : Color
    {
        public override void Paint()
        {
            Console.WriteLine("Green");
        }
    }

    public abstract class AbstractFactorys
    {
        public abstract Color getColor(string item);
        public abstract Shapes getShape(string item);
    }

    public class ShapeFactorys : AbstractFactorys
    {
        public override Color getColor(string item)
        {
            throw new NotImplementedException();
        }

        public override Shapes getShape(string item)
        {
            if (item == "circle")
                return new Circles();
            else if (item == "square")
                return new Squares();

            return null;
        }
    }

    public class ColorFactory : AbstractFactorys
    {
        public override Color getColor(string item)
        {
            if (item == "red")
                return new Red();
            else if (item == "green")
                return new Green();

            return null;
        }

        public override Shapes getShape(string item)
        {
            throw new NotImplementedException();
        }
    }

    public static class FactoryProducer
    {
        public static AbstractFactorys getFactory(string item)
        {
            if(item == "shape")
                return new ShapeFactorys();
            else if(item == "color")
                return new ColorFactory();

            return null;
        }
    }


    internal class AbstractFactory
    {
        public AbstractFactory()
        {
            AbstractFactorys abstractFactorys1 = FactoryProducer.getFactory("color");
            abstractFactorys1.getColor("red");

            AbstractFactorys abstractFactorys2 = FactoryProducer.getFactory("shape");
            abstractFactorys2.getShape("square");
        }
    }
}
