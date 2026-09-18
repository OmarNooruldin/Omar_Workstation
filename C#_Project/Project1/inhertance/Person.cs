using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.inhertance
{
    class Person
    {
        string _name;

        public string Name { 
            get { return _name; }
            set { _name = Equals(null) ? "No Name" : value; }
        }

        public Person(string name)
        {
           Name = name;
        }

    }
}
