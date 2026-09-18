using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Interface
{
    class Student_Interface : Person, IPrintable
    {
        // Attributes //

        double _mark;
        double _fullmark;


        // Properties //
        public double Mark
        {
            get { return _mark; }
            set { _mark = value < 0 ? 0 : value; }
        }

        // Properties //
        public double FullMark
        {
            get { return _fullmark; }
            set { _fullmark = value < 0 ? 0 : value; }
        }


        // Constructor //
        public Student_Interface(string name, double mark, double full_mark) : base(name)
        {
            Mark = mark;
            FullMark = full_mark;
        }


        // Inhertance From Abstract Class 
        public override string GetInfo()
        {
            return
                   $" Student Name IS {Name} \n "                  +
                   $"Student Mark IS {Mark} \n "                  +
                   $"Student Percentage IS {GetPercentage()} % \n " +
                   $"Student Grade IS {GetGrade()} \n ";
        }


        // Implement From Interface
        public void PrintInfo()
        {
              Console.WriteLine(GetInfo());
        //    Console.WriteLine($"Student Name IS {Name} \n "                  +
        //                      $"Student Mark IS {Mark} \n "                  +
        //                      $"Student Percentage IS {GetPercentage()} \n " +
        //                      $"Student Grade IS {GetGrade()} \n ");
        }

        // function //
        public void GetStudentlabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Student Information");
            Console.WriteLine("=============================");
        }



        // Function //
        public double GetPercentage()
        {
            return Mark / FullMark * 100;
        }

        // Function //
        public string GetGrade()
        {
            string grade =
               (Mark > 85) ? "A" :
               (Mark > 75) ? "B" :
               (Mark > 65) ? "C" :
               (Mark > 50) ? "D" : "Failed";

            return grade;
        }


        // Function //
        public string[] GetStudentResult()
        {
            return new string[]
            {
            "The Student Name is " + Name,
            "The Student Mark is " + Mark ,
            "The Student Percentage is " + GetPercentage() + "%",
            "The Student Grade is " + GetGrade()
            };

        }


        // Function //
        public void GetStudentResultPrint()
        {
            string[] result = GetStudentResult();

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }

       
    }
}
