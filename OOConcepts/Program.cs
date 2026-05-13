namespace OOConcepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Triangle();
            DrawSomeShape(s);

        }

        static void DrawSomeShape(Shape a)
        {
            a.Draw();
        }

    }


    //interface Shape
    abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw(); // non-polymarphic
        //{
        //    Console.WriteLine("Drawing Shape");
        //}
        public abstract double CalculateArea();
        //{
        //    Console.WriteLine("Calcuating shape area");
        //    return Width * Height;
        //}
    }

    interface ThreeDShape
    {

    }

    interface OtherInterface { }

    class Rectangle : Shape, ThreeDShape, OtherInterface  // IS-A - Generalization - BAD
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }
        public override double CalculateArea()
        {
            throw new NotImplementedException();
        }
    }

    class Triangle : Shape 
    {

        override public void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }
         override public double CalculateArea() // Method Hiding
        {
            Console.WriteLine("Calculating Triangle area");
            return Width * Height / 2;
            //double area = base. CalculateArea();
            //return area / 2;
        }
    }
}
