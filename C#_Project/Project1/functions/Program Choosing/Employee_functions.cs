using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Program_Choosing
{
    class Employee_functions
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


        public Employee_functions(string name, double salary) 
        {
            Name = name;
            Salary = salary;
        }

        public Employee_functions()
        {
        }

        public void GetEmployeelabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Employee Information");
            Console.WriteLine("=============================");
        }


        public object[] GetInfoFromUser()
        {

            Console.WriteLine("Enter Employee Name");
            Name = Console.ReadLine();

            Console.WriteLine("Enter your Monthly Salary");
            Salary = Convert.ToDouble(Console.ReadLine());

            return new object[] { Name, Salary };

        }


         public double GetEmployeeAnnualSalary()
        {
            return Salary * 12;
        }

         public string GetSalaryLevel( )
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
