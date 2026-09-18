using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Loopss
{
    class enhanced_Program
    {
        //static void Main(string[] args)
        //{
        //    int choose;
        //    double mark;
        //    double Full_M = 100;
        //    double weight;
        //    double height;
        //    int salary;
        //    int month;

        //    Console.WriteLine("Choose one of the following choices :-  \n  1:- Calculate your Exam percentage  \n  " +
        //        "  2:- Calculate your BMI:- \n      3:- Calculate ypur annual salary  \n" +
        //         "         4:-To check how many days in month        \n            (Type any other number to exit program) ");

        //    choose = Convert.ToInt32(Console.ReadLine());

        //    switch (choose)
        //    {
        //        case 1:

        //            Console.WriteLine("Enter your Mark :- ");
        //            mark = Convert.ToDouble(Console.ReadLine());

        //            Double percentage = mark / Full_M * 100;
        //            Console.WriteLine("This is your percantage :- " + percentage + "%");

        //            if (percentage >= 85)
        //            {
        //                Console.WriteLine("Excellent ");
        //            }

        //            else if (percentage >= 75)
        //            {
        //                Console.WriteLine("Very Good ");
        //            }

        //            else if (percentage >= 65)
        //            {
        //                Console.WriteLine("Good ");
        //            }

        //            else if (percentage >= 50)
        //            {
        //                Console.WriteLine("Pass ");
        //            }

        //            else
        //            {
        //                Console.WriteLine("Failed ");
        //            }

        //            break;


        //        case 2:

        //            Console.WriteLine("Enter your weight :- ");
        //            weight = Convert.ToDouble(Console.ReadLine());

        //            Console.WriteLine("Enter the height :- ");
        //            height = Convert.ToDouble(Console.ReadLine());

        //            Double BMI = weight / (height * height);
        //            Console.WriteLine("This is your BMI :- " + BMI);


        //            if (BMI >= 25)
        //            {
        //                Console.WriteLine("You are over weight ");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Your weight is healthy ");
        //            }

        //            break;

        //        case 3:

        //            Console.WriteLine("Enter your salary :- ");
        //            salary = Convert.ToInt32(Console.ReadLine());

        //            int annual_S = salary * 12;
        //            Console.WriteLine("This is your annual salary :- " + annual_S);


        //            if (annual_S > 180000)
        //            {
        //                Console.WriteLine("Your Salary is high ");
        //            }
        //            else if (annual_S > 120000)
        //            {
        //                Console.WriteLine("Your Salary is Medium ");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Your Salary is Low ");
        //            }

        //            break;

        //        case 4:

        //            Console.WriteLine("Enter the number of month to check the number of days ");
        //            month = Convert.ToInt32(Console.ReadLine());

        //            switch (month)
        //            {

        //                case 2:
        //                    Console.WriteLine("This month have either 28 or 29 days ");
        //                    break;


        //                case 1:
        //                case 3:
        //                case 5:
        //                case 7:
        //                case 8:
        //                case 10:
        //                case 12:
        //                    Console.WriteLine("This month have 31 days ");
        //                    break;

        //                case 4:
        //                case 6:
        //                case 9:
        //                case 11:
        //                    Console.WriteLine("This month have 30 days ");
        //                    break;

        //                default:
        //                    Console.WriteLine("Invalid Input");
        //                    break;


        //            }

        //            break;

        //        default:

        //            Console.WriteLine("You exit the program ");

        //            break;

        //    }
        //}
    }
}
