using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task_Abstract_Interface
{
    class TestTask
    {
        //static void Main(string[] args)
        //{
        //    Employee employee = new Employee("Omar", 15000);

        //    employee.GetLabel();

        //    Console.WriteLine($"Employee Name IS {employee.Name}");

        //    Console.WriteLine($"Employee Salary IS {employee.Salary}");

        //    Console.WriteLine($"Employee Salary Level IS {employee.GetSalaryLevel(employee.CalculateAnnualSalary())}");

        //    Console.WriteLine($"Employee Annual Salary = {employee.CalculateAnnualSalary()}");
        //}

    }



    public abstract class EmployeeBase 
    {

        string _name;
        double _salary;

      

        public string Name
        {
            get { return _name; }
            set { _name = Equals(null) ? "No Name" : value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value < 0 ? 0 : value; }
        }


        public EmployeeBase(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public abstract double CalculateAnnualSalary();

    }

    public interface ISalaryLevel 
    {
        string GetSalaryLevel(double annualSalary);
        void GetLabel();
    
    }


    public class Employee : EmployeeBase, ISalaryLevel
    {

        public Employee(string name, double salary):base(name,salary)
        {
        }


        public override double CalculateAnnualSalary()
        {
            return Salary * 12;
        }


        public void GetLabel()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("==== Employee Information ====");
            Console.WriteLine("===============================");

        }

        public string GetSalaryLevel(double annualSalary)
        {
            return (annualSalary >= 15000) ? "High Salary"   :
                   (annualSalary >= 10000) ? "Normal Salary" :
                   (annualSalary >= 5000) ? "Low Salary"     : "Very Low Salary";
        }

    }

}
