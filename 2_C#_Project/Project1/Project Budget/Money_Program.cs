using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Project
{
    class Money_Program : Money, Money_Interface
    {
        string _name;

        public string Name { get => _name; set => _name = value; }


        public Money_Program() { }

        public Money_Program(string name,double salary,double food,double gas, double subscriptions, double entertainment, double insurance, double loan)
            : base(salary, food, gas, subscriptions, entertainment, insurance, loan)
        {
            Name = name;
        }

        public void GetSalaryDetails()
        {
            Console.WriteLine(
                               $"Salary = {Salary}" +
                               $"Food = {Food}" +
                               $"Gas = {Gas}" +
                               $"Subscriptions = {Subscriptions}" +
                               $"Entertainment = {Entertainment}" +
                               $"Insurance = {Insurance}" +
                               $"Loan = {Loan} ");
        }

        public double CalculateSaving()
        {
            return (Salary - Food - Gas - Subscriptions - Entertainment - Insurance - Loan) ;

        }




    }
}
