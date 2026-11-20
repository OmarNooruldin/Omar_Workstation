using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Project
{
    abstract class Money
    {
        double _salary;
        double _food;
        double _gas;
        double _subscriptions;
        double _entertainment;
        double _insurance;
        double _loan;
      

        public double Salary { get => _salary; set => _salary = value; }
        public double Food { get => _food; set => _food = value; }
        public double Gas { get => _gas; set => _gas = value; }
        public double Subscriptions { get => _subscriptions; set => _subscriptions = value; }
        public double Entertainment { get => _entertainment; set => _entertainment = value; }
        public double Insurance { get => _insurance; set => _insurance = value; }
        public double Loan { get => _loan; set => _loan = value; }

        public Money(double salary, double food, double gas, double subscriptions, double entertainment, double insurance, double loan)
        {
            Salary = salary;
            Food = food;
            Gas = gas;
            Subscriptions = subscriptions;
            Entertainment = entertainment;
            Insurance = insurance;
            Loan = loan;

        }

        public Money() { }


        public object[] GetFromUser()
        {
            Console.WriteLine("Enter your Salary :");
            Salary =Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Food budget :");
            Food = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Gas budget :");
            Gas = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Susbscrptions budget :");
            Subscriptions = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Entertainment budget :");
            Entertainment = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insurance budget :");
            Insurance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Loan budget :");
            Loan = Convert.ToDouble(Console.ReadLine());

            return new object[] { Salary, Food, Gas, Subscriptions, Entertainment, Insurance, Loan };
        }

    }
}
