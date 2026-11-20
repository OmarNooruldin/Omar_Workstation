using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Patient
{
     class patient
    {

        public void GetPatientlabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Patient Information");
            Console.WriteLine("=============================");
        }

        public object[] GetFromUser()
        {

            Console.WriteLine("Enter Your Name :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Your Weight :");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Your Height :");
            double height = Convert.ToDouble(Console.ReadLine());


            return new object[]  { name, weight, height };
           
        }


        public double GetBMI(double weight, double height)
        { 
            return weight / (height *  height);
        }


        public string GetBodyStatus(double weight, double height)
        {
            string level =

            (GetBMI(weight,height) < 18.5) ? "Under Weight" :
            (GetBMI(weight, height) >= 18) && (GetBMI(weight, height) < 24.9) ? "Normal Weight" :
            (GetBMI(weight, height) >= 25) && (GetBMI(weight, height) < 24.9) ? "Over Weight" : "Not Normal ";
        
            return level;
        }


        public string[] GetPatientInfo()
        {
            object[] input = GetFromUser();

            return new string[]
            {

            $"The Patient Name is :       {input[0]}",
            $"The Patient Weight is :     {input[1]}",
            $"The Patient Height is :     {input[2]}" ,
            $"The Patient BMI is :        {GetBMI(Convert.ToDouble(input[1]),Convert.ToDouble(input[2])) }",
            $"The Patient BMI Level is :  {GetBodyStatus(Convert.ToDouble(input[1]),Convert.ToDouble(input[2]))}"

            };
        }


        public void GetPatientInfoPrint()
        {
            object[] print = GetPatientInfo();

            foreach (object o in print)
            {
                Console.WriteLine(o);
            }
        }

    }
}
