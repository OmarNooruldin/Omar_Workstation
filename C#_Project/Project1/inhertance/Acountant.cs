using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.inhertance
{
    class Acountant : Empolyee
    {

        public double Tax 
        {  
            get;
            set;
        }

        public Acountant(string name, double salary,double tax):base(name, salary)
        {
            Tax = tax;
        }

        public override double GetNetSalary()
        {
            return base.GetNetSalary() - Tax ;
        }


    }
}
