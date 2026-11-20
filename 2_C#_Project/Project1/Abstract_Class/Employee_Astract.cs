using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract_Class
{
    class Employee_Astract : Person
    {

        double _salary;

        public double Salary
        {
            get { return _salary; }
            set { _salary = value < 0 ? 0 : value; }
        }


        public Employee_Astract(string name, double salary):base(name) 
        {
                Salary = salary;
        }


        public virtual double GetNetSalary()
        {
            return Salary;
        }


        public override string GetInfo()
        {
            return
                   $"Employee Name IS {Name} \n " +
                   $"Employee Salary IS {GetNetSalary()} \n " +
                   $"Employee Salary Level IS {GetSalaryLevel()} \n " +
                   $"Employee Annual Salary IS {GetEmployeeAnnualSalary()} \n ";
        }



        public void GetEmployeelabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Employee Information");
            Console.WriteLine("=============================");
        }



        public double GetEmployeeAnnualSalary()
        {
            return Salary * 12;
        }

        public string GetSalaryLevel()
        {
            string level = (Salary >= 15000) ? "High Salary" :
                           (Salary >= 10000) ? "Normal Salary" :
                           (Salary >= 5000) ? "Low Salary" : "Very Low Salary";

            return level;
        }

        public string GetAnnualSalaryLevel()
        {
            string level = (GetEmployeeAnnualSalary() >= 180000) ? "High Salary" :
                           (GetEmployeeAnnualSalary() >= 120000) ? "Normal Salary" :
                           (GetEmployeeAnnualSalary() >= 60000) ? "Low Salary" : "Very Low Salary";

            return level;
        }

        public string[] GetEmployeeSummary()
        {

            return new string[]
            {
            "The Employee Name is : "          + Name ,
            "The Employee Salary is : "        + Salary ,
            "The Employee Salary Level is : "  + GetSalaryLevel(),
            "The Employee Annual Salary is : " + GetEmployeeAnnualSalary() ,
            "The Employee Annual Salary is : " + GetAnnualSalaryLevel()

            };

        }

        public void GetEmployeeSummaryPrint()
        {
            string[] e_result = GetEmployeeSummary();

            foreach (string s in e_result)
            {
                Console.WriteLine(s);
            }
        }

    }
}
