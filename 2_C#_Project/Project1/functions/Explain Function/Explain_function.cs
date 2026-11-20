using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions
{
    class Explain_function
    {

        public static void static_add()
        {
            Console.WriteLine("pls enter Number 1");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("pls enter Number 2");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"The result is {num1 + num2}");

        }


         public static void static_sub()
        {
            Console.WriteLine("pls enter Number 1");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("pls enter Number 2");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"The result is {num1 - num2}");

        }

        public void instance_mult()
        {
            Console.WriteLine("pls enter Number 1");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("pls enter Number 2");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"The result is {num1 * num2}");

        }

        public void instance_divid()
        {
            Console.WriteLine("pls enter Number 1");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("pls enter Number 2");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"The result is {num1 / num2}");

        }


        public static double Retured_add()
        {
            Console.WriteLine("pls enter Number 1");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("pls enter Number 2");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("The result is ");

            return num1 + num2; 
        }


        public static double Retured_add_with_parameter(double num1,double num2)
        {
            return num1 + num2;
        }




        //static void Main(string[] args)
        //{
        //    static_add();
        //    static_sub();

        //    ////////////////////////////////////////////////////////////////////////////////////////////////

        //    Retured_add();
        //    double result = Retured_add();
        //    Console.WriteLine(result);
        //    Console.WriteLine(Retured_add());

        //    ////////////////////////////////////////////////////////////////////////////////////////////////

        //    Retured_add_with_parameter(25, 5);
        //    Console.WriteLine(Retured_add_with_parameter(5, 10));

        //    Console.WriteLine("pls enter Number 1");
        //    double no1 = Convert.ToDouble(Console.ReadLine());

        //    Console.WriteLine("pls enter Number 2");
        //    double no2 = Convert.ToDouble(Console.ReadLine());

        //    Console.WriteLine(Retured_add_with_parameter(no1, no2));

        //    //////////////////////////////////////////////////////////////////////////////////////////////////

        //    Explain_function exfun = new Explain_function();

        //    exfun.instance_mult();
        //    exfun.instance_divid();

        //}
    }
}
