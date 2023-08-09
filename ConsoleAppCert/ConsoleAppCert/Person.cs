using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCert
{
    public class Person
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
