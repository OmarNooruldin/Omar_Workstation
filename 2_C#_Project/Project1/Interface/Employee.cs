using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Interface
{

    public abstract class Employee
    {
        private string _name;
        private double _salary;

        public string Name { get; set; }

        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;

        }

        public abstract double GetSalary();

    }


    public class EmployeeBasic : Employee
    {
        private double _commision;

        public double Commision { get; set; }

        public EmployeeBasic(string name, double salary, double commision) : base(name, salary)
        {
            Commision = commision;
        }


        public override double GetSalary()
        {
            return (Salary * 12) + Commision;
        }
    }

    public class EmployeeHourly : Employee
    {
        private double _overtime;

        public double Overtime { get => _overtime; set => _overtime = value; }


        public EmployeeHourly(string name, double salary, double overtime) : base(name, salary)
        {
            Overtime = overtime;
        }

        public override double GetSalary()
        {
            return (Salary * 12) + Overtime;
        }

    };


}