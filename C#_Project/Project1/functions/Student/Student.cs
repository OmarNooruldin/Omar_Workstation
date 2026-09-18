using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Student
{
    class Student
    {
        string _name;
        double _mark;
        double _fullmark;

        public string Name
        {
            get { return _name; }
            set { _name = value.Equals(null) ? "No Name" : value; }
        }

        public double Mark
        {
            get { return _mark; }
            set { _mark = value < 0 ? 0 : value; }
        }

        public double FullMark
        {
            get { return _fullmark; }
            set { _fullmark = value < 0 ? 0 : value; }
        }


        public Student(string name, double mark, double full_mark)
        {
            Name = name;
            Mark = mark;
            FullMark = full_mark;
        }


        public double GetPercentage()
        {
            return Mark / FullMark * 100;
        }

        public string GetGrade()
        {
            string grade =
               (Mark > 85) ? "A" :
               (Mark > 75) ? "B" :
               (Mark > 65) ? "C" :
               (Mark > 50) ? "D" : "Failed";

            return grade;
        }

    }
}

