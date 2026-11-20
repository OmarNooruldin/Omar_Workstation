using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Program_Choosing
{
    class Patient_functions
    {

       string _name;
       double _weight;
       double _height;


        public Patient_functions(string name, double weight, double height)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public Patient_functions()
        {
        }

        public string Name 
        {
            get { return _name; }
            set { _name = Equals(null) ? "No Name" : value ; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value < 0 ? 0 : value ; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

      

        public void GetPatientLabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Patient Information");
            Console.WriteLine("=============================");

        }

        public object[] GetInfoFromUser()
        {

            Console.WriteLine("Enter Patient Name");
             Name= Console.ReadLine();

            Console.WriteLine("Enter your Weight");
             Weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your Height");
             Height = Convert.ToDouble(Console.ReadLine());


            return new object[] { Name, Weight, Height };

        }


        public double GetBMI()
        {
            return Weight / (Height * Height);
        }

        public string GetBodyStatus()
        {   
            return (GetBMI() < 18.5) ? "Under Weight" :
                   (GetBMI() >= 18.5 && GetBMI() < 24.9) ? "Normal Weight" :
                   (GetBMI() >= 25 && GetBMI() < 24.9) ? "Over Weight" : "Not Normal";
        }

        public string[] GetPatientBMI()
        {
            return new string[] {

                "Patient Name   : "      + Name ,
                "Patient Weight : "      + Weight ,
                "Patient Height : "      + Height ,
                "Patient BMI    : "      + GetBMI() ,
                "Patient BMI Level: "    + GetBodyStatus() ,
                "Patient Body Status : " + GetBodyStatus()

        };
        }


        public void GetPatientPrint()
        {
            string[] result = GetPatientBMI();

            foreach (string p in result)
            {
                Console.WriteLine(p);
            }
                
        }
    }
}
