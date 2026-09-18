using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract_Class
{
    class Rectangle : Shape
    {
        double _length;
        double _width;

        public double Length { get => _length; set => _length = value; }
        public double Width { get => _width; set => _width = value; }


        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea()
        {
            return Length * Width;
        }

        public override void PrintArea()
        {
            Console.WriteLine($"Area of Rectangle = {GetArea()}");
            Console.WriteLine("========================= \n");
        }



    }
}
