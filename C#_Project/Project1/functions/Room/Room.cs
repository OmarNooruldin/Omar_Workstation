using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Project1.functions.Room
{
     class Room
    {
        public double _length;
        public double _width;
        public double _height;

        public double Length
        {
            get { return _length; }
            set { _length = value > 0 ? value : 0 ; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value > 0 ? value : 0 ; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value > 0 ? value : 0 ; }
        }


        public Room(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public Room()
        {
        }


        public void GetRoomlabel()
        {
            Console.WriteLine("=============================");
            Console.WriteLine(" Room Information ");
            Console.WriteLine("=============================");
        }


        public object[] GetFromUser()
        {
            Console.WriteLine("Enter The Length");
            Length = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter The Width");
            Width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter The Length");
            Height = Convert.ToDouble(Console.ReadLine());


            return new object[] { Length, Width, Height };
        }


        public double GetVolume()
        {
            return (Length * Width * Height);
        }

        public string[] GetVolumeLabel()
        {
            return new string[]
              {
                "This is the length of the room = " + Length + " m",
                "This is the Width of the room = " + Width + " m",
                "This is the Height of the room = " + Height + " m",
                "This is the volume of the room = " + GetVolume() + " m^3",
              };
        }

        public void GetVolumePrint()
        {
            string[] v_result = GetVolumeLabel();
            foreach (string v in v_result)
            {
                Console.WriteLine(v);
            }
        }


     }
}
