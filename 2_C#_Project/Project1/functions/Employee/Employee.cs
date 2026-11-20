using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Employee
{
     class Employee
    {
      
        public void GetEmployeelabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Employee Information");
            Console.WriteLine("=============================");
        }


        public object[] GetFromUser()
        {

              Console.WriteLine("Enter Your Name :");
               string name = Console.ReadLine();

              Console.WriteLine("Enter Your Salary :");
               double salary = Convert.ToDouble(Console.ReadLine());


            return new object[]  { name , salary};
        }


        public double GetAnnualSalary(double salary)
        {        
            return salary * 12;
        }


        public string GetSalaryLevel(double salary)
        {
            string level =
                (salary >= 15000) ? "High Salary" :
                (salary >= 10000) ? "Normal Salary" :
                (salary >= 5000) ? "Low Salary" : "Very Low Salary" ;

            return level;
        }

        public string GetAnnualSalaryLevel(double salary)
        {
            
            string Annuallevel = (GetAnnualSalary(salary) >= 180000) ? "High Salary" :
                                 (GetAnnualSalary(salary) >= 120000) ? "Normal Salary" :
                                 (GetAnnualSalary(salary) >= 65000 ) ? "Low Salary" : "Very Low Salary";

            return Annuallevel;
        }

        public string[] GetEmployeeInfo()
        {
            object[] input =GetFromUser();

            return new string[]
            {

            $"The Employee Name is :                          {input[0]}",
            $"The Employee Salary is :                        {input[1]}",
            $"The Employee Salary Level is :                  {GetSalaryLevel(Convert.ToDouble(input[1]))}" ,
            $"The Employee Annual Salary is :                 {GetAnnualSalary(Convert.ToDouble(input[1])) }",
            $"The Employee Annual Salary Level is :           {GetAnnualSalaryLevel(Convert.ToDouble(input[1]))}" 

            };
            }


        public void GetEmployeePrint() 
        {
            object[] result =  GetEmployeeInfo();

            foreach (string s in result)
            {
                Console.WriteLine (s);
            }

        }

        //public void GetEmployeelabel()
        //{
        //    Console.WriteLine("=============================");
        //    Console.WriteLine("Employee Information");
        //    Console.WriteLine("=============================");
        //}


        //public object[] GetInfoFromUser()
        //{

        //    Console.WriteLine("Enter Employee Name");
        //    EmpName = Console.ReadLine();

        //    Console.WriteLine("Enter your Monthly Salary");
        //    EmpSalary = Convert.ToDouble(Console.ReadLine());

        //    return new object[] { EmpName, EmpSalary };

        //}


        //public double GetEmployeeAnnualSalary()
        //{
        //    return EmpSalary * 12;
        //}

        //public string GetSalaryLevel()
        //{
        //    string level = (EmpSalary >= 15000) ? "High Salary" :
        //                   (EmpSalary >= 10000) ? "Normal Salary" :
        //                   (EmpSalary >= 5000) ? "Low Salary" : "Very Low Salary";

        //    return level;
        //}

        //public string GetAnnualSalaryLevel()
        //{
        //    string level = (GetEmployeeAnnualSalary() >= 180000) ? "High Salary" :
        //                   (GetEmployeeAnnualSalary() >= 120000) ? "Normal Salary" :
        //                   (GetEmployeeAnnualSalary() >= 60000) ? "Low Salary" : "Very Low Salary";

        //    return level;
        //}

        //public string[] GetEmployeeSummary()
        //{

        //    return new string[]
        //    {
        //    "The Employee Name is : "          + EmpName ,
        //    "The Employee Salary is : "        + EmpSalary ,
        //    "The Employee Salary Level is : "  + GetSalaryLevel(),
        //    "The Employee Annual Salary is : " + GetEmployeeAnnualSalary() ,
        //    "The Employee Annual Salary is : " + GetAnnualSalaryLevel()

        //    };

        //}

        //public void GetEmployeeSummaryPrint()
        //{
        //    string[] e_result = GetEmployeeSummary();

        //    foreach (string s in e_result)
        //    {
        //        Console.WriteLine(s);
        //    }


            //static void Main(string[] args)
            //{
            //    Console.WriteLine(GetEmployeeInfo("Omar", 5000));
            //}
        }
}
