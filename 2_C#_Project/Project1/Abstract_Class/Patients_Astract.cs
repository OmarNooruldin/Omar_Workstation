using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Abstract_Class
{
    class Patients_Astract : Person
    {

        double _weight;
        double _height;


        public Patients_Astract(string name, double weight, double height):base(name)
        {
            Weight = weight;
            Height = height;
        }

        
        public double Weight
        {
            get { return _weight; }
            set { _weight = value < 0 ? 0 : value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        public override string GetInfo()
        {
            return
                   $"Patient Name IS {Name} \n " +
                   $"Patient Weight IS {Weight} \n " +
                   $"Patient Height IS {Height} \n " +
                   $"Patient BMI IS {GetBMI()} \n " +
                   $"Patient Body Status IS {GetBodyStatus()} \n ";
        }


        public void GetPatientLabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine("Patient Information");
            Console.WriteLine("=============================");

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
