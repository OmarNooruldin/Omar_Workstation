using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Task3_Abstract_Interface
{
    class TestTask3
    {
        //static void Main(string[] args)
        //{
        //   Patient patient = new Patient("Omar", 59, 1.71);

        //   patient.GetLabel();

        //   Console.WriteLine($"Patient Name IS = {patient.Name}");

        //   Console.WriteLine($"Patient Weight IS = {patient.Weight}");

        //   Console.WriteLine($"Patient Height IS = {patient.Height}");

        //   Console.WriteLine($"Patient BMI IS = {patient.GetBMI()} ");

        //   Console.WriteLine($"Patient Body Status IS = {patient.GetStatus(patient.GetBMI())}");


        //}

    }

    public abstract class PatientBase 
    {
        string _name;
        double _weight;
        double _height;

        public string Name
        {
            get { return _name; }
            set { _name = Equals(null) ? "No Name" : value; }
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


        public PatientBase(string name, double weight, double height)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }


        public abstract double GetBMI();
    
    }


    public  interface IBodyStatus 
    {
        string GetStatus(double bmi);
        void GetLabel();

    }


    public class Patient : PatientBase, IBodyStatus
    {
        public Patient(string  name, double weight, double height) : base(name, weight, height)
        {
        }   

        public override double GetBMI()
        {
            return Weight / (Height * Height);
        }

        public void GetLabel()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("==== Patient Information ====");
            Console.WriteLine("===============================");
        }

        public string GetStatus(double bmi)
        {
            return (GetBMI() < 18.5)                     ? "Under Weight"  :
                   (GetBMI() >= 18.5 && GetBMI() < 24.9) ? "Normal Weight" :
                   (GetBMI() >= 25 && GetBMI() < 24.9)   ? "Over Weight"   : "Not Normal";

        }


    }
}
