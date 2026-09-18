using Project1.functions.Patient;
using Project1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task2_Abstract_Interface
{
    class TestTask2
    {
        //static void Main(string[] args)
        //{

        //    Student student = new Student("Omar", 98, 100);

        //    student.GetLabel();

        //    Console.WriteLine($"Student Name IS {student.Name}");

        //    Console.WriteLine($"Student Mark IS {student.Mark}");

        //    Console.WriteLine($"The Exam Is From {student.FullMark}");

        //    Console.WriteLine($"Student Percentage = {student.GetPercentage()}%");

        //    Console.WriteLine($"Student Grade IS {student.GetGrade(student.GetPercentage())}");



        //}
    }

        public abstract class StudentBase
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


        public StudentBase(string s_name, double s_mark, double s_full_mark)
        {
            Name = s_name;
            Mark = s_mark;
            FullMark = s_full_mark;
        }


        public abstract double GetPercentage();

    }

    public interface IGrading
    {
        string GetGrade(double percentage);

        void GetLabel();

    }

    public class Student : StudentBase, IGrading
    {
        public Student(string name,
                       double mark,
                       double full_mark) : base(name, mark, full_mark)
        {
        }


        public override double GetPercentage()
        {
            return (Mark / FullMark) * 100;
        }

        public string GetGrade(double percentage)
        {

            return (percentage >= 90) ? "A" :
                   (percentage >= 80) ? "B" :
                   (percentage >= 70) ? "C" :
                   (percentage >= 60) ? "D" : "Fail";

        }

        public void GetLabel()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("==== Student Information ====");
            Console.WriteLine("===============================");
        }
    
    }
}
