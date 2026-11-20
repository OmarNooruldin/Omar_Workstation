using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.inhertance
{
    class Developer : Empolyee
    {
        public double OvertimeHours { get; set; }

        public double HourRate { get; set; }

        public Developer(string name, double salary , double overtimeHours, double hourRate) : base(name, salary)
        {
            OvertimeHours = overtimeHours;
            HourRate = hourRate;
        }

     
        public override double GetNetSalary()
        {
            return (OvertimeHours * HourRate) + Salary ;
        }
    }
}