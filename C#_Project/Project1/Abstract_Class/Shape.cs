using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract_Class
{
   abstract class Shape
    {  
        public abstract double GetArea();

        public abstract void PrintArea();

        public void PrintText()
        {
            Console.WriteLine("Shape Class");
        }

    }
}
