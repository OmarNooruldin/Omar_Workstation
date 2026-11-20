using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Calculator
{
    class calculator
    {

        public int Additon(int x, int y)
        { return x + y; }

        public int Subtraction(int x, int y)
        { return x - y; }

        public int Multiply(int x, int y)
        { return x * y; }

        public double Division(int x, int y)
        { return x / y; }



        //static void Main(string[] args)
        //{
            //    //calculator ca1 = new calculator();
            //    //calculator ca2 = new calculator();
            //    //calculator ca3 = new calculator();
            //    //calculator ca4 = new calculator();

            //    //int no1;
            //    //int no2;
            //    //int cho;


            //    //do
            //    //{
            //    //    Console.WriteLine("Choose operation --> " +
            //    //        " \n 1:- Addition " +
            //    //        " \n 2:- Subtraction  " +
            //    //        "\n 3:- Multiply \n " +
            //    //        "4:- Divide  \n 5:- To exit ");

            //    //    cho = Convert.ToInt32(Console.ReadLine());

            //    //    switch (cho)
            //    //    {
            //    //        case 1:

            //    //            Console.WriteLine("Enter your first number = ");
            //    //            no1 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("Enter your second number = ");
            //    //            no2 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("The result of addition is = " + ca1.Additon(no1, no2));

            //    //            break;


            //    //        case 2:

            //    //            Console.WriteLine("Enter your first number = ");
            //    //            no1 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("Enter your second number = ");
            //    //            no2 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("The result of Subtraction is = " + ca2.Subtraction(no1, no2));

            //    //            break;


            //    //        case 3:


            //    //            Console.WriteLine("Enter your first number = ");
            //    //            no1 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("Enter your second number = ");
            //    //            no2 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("The result of multiplication is = " + ca3.Multiply(no1, no2));

            //    //            break;


            //    //        case 4:

            //    //            Console.WriteLine("Enter your first number = ");
            //    //            no1 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("Enter your second number = ");
            //    //            no2 = Convert.ToInt32(Console.ReadLine());

            //    //            Console.WriteLine("The result of divide is = " + ca4.Division(no1, no2));

            //    //            break;

            //    //        case 5:
            //    //            Console.WriteLine("You exit the program ");
            //    //            break;
            //    //        default:
            //    //            Console.WriteLine("Invalid Number");
            //    //            break;
            //    //    } 
            //    //} while (cho != 5);


   
    //}
}
}