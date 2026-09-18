using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract_Class
{
    class Circle : Shape
    {
        double _radius;
        
        public double Radius { get => _radius; set => _radius = value; }
     
        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return (Radius * Radius) * Math.PI ;
        }

        public override void PrintArea()
        {
            Console.WriteLine($"Area of Circle = {GetArea()}");
            Console.WriteLine("=========================");
        }

    }
}
