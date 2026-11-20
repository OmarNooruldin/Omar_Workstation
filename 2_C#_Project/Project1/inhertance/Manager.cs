using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.inhertance
{
     class Manager : Empolyee
    {

        public double Bonus
        { get; set; }


        public Manager(string name, double salary ,double bonus):base(name, salary)
        {
            Bonus = bonus;
        }

        public override double GetNetSalary()
        {
            return Bonus + Salary;
        }

    }
}
