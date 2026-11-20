using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Calculator
{
    class StudentInfo
    {

        public void GetStudentlabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Student Information");
            Console.WriteLine("=============================");
        }


        public object[] GetFromUser()
        {
            Console.WriteLine("Enter Your Name :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Your Mark :");
            double mark = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter The Full Mark :");
            double fullmark = Convert.ToDouble(Console.ReadLine());

            return new object[] { name, mark, fullmark };
        }
         

        public double GetStudentPercentage(double mark, double fullmark)
        {
            return (mark/fullmark) * 100 ;
        }


        public string GetStudentGrade(double mark, double fullmark)
        {
            
            string grade =
                           (GetStudentPercentage(mark, fullmark) >= 85) ? "Excellent" :
                           (GetStudentPercentage(mark, fullmark) >= 75) ? "Very Good" :
                           (GetStudentPercentage(mark, fullmark) >= 65) ? "Good " :
                           (GetStudentPercentage(mark, fullmark) >= 50) ? "Pass " : "Failed";

            return grade;
        }

        public string[] GetStudentInfo()
        { 

            object[] input = GetFromUser();
 
                 return new string[]
            {
               $"The name of Student is {input[0]} ",
               $"The mark of Student is {input[1]}",
               $"The percentage of Student is {GetStudentPercentage(Convert.ToDouble(input[1]),Convert.ToDouble(input[2]))} %",
               $"The grade of Student is {GetStudentGrade(Convert.ToDouble(input[1]),Convert.ToDouble(input[2]))} ",

             };

        }


        public void GetStudentInfoPrint()
        {
            object[] result = GetStudentInfo();

            foreach (object o in result)
            {
                Console.WriteLine (o);
            }
        }


        //static void Main(string[] args)
        //{
        //    StudentInfo std = new StudentInfo();

        //    std.GetStudentlabel();

        //    std.GetStudentInfoPrint();

        //}
    }
}
