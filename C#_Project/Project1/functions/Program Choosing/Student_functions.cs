using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Program_Choosing
{
     class Student_functions
    {
        // Attributes //
        string _name;
        double _mark;
        double _fullmark;


        // Properties //
        public string Name
        {
            get { return _name; }
            set { _name = value.Equals(null) ? "No Name" : value; }
        }

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
        public Student_functions(string name, double mark, double full_mark)
        {
            Name = name;
            Mark = mark;
            FullMark = full_mark;
        }

        public Student_functions()
        {
        }


        // function //
        public void GetStudentlabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Student Information");
            Console.WriteLine("=============================");
        }


        // function //
        public object[] GetFromUser()
        {
            Console.WriteLine("Enter Your Name : ");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Your Mark : ");
            Mark = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Your Full Mark : ");
            FullMark = Convert.ToDouble(Console.ReadLine());

            return new object[] { Name, Mark, FullMark };
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
