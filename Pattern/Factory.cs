using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public abstract class Shape
    {
        public Shape()
        {
            this.Draw();
        }
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Square");
        }
    }

    public static class ShapeFactory
    {
        public static Shapes getShape(string item)
        {
            if(item == "circle")
                return new Circles();
            else if(item == "square")
                return new Squares();

            return null;
        }
    }


    internal class Factory
    {
        public Factory()
        {
            Shapes cir = ShapeFactory.getShape("circle");
            Shapes sqa = ShapeFactory.getShape("square");
        }
    }
}
