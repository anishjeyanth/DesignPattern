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
        public static Shape getShape(string item)
        {
            if(item == "circle")
                return new Circle();
            else if(item == "square")
                return new Square();

            return null;
        }
    }


    internal class SimpleFactory
    {
        public SimpleFactory()
        {
            Shape cir = ShapeFactory.getShape("circle");
            Shape sqa = ShapeFactory.getShape("square");
        }
    }
}
