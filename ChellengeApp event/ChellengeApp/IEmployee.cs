using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChellengeApp
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }
        char Sex { get; }
        int Age { get; }
        string NameFather { get; }

        Statistics GetStatistics();
        void AddGrade(float grade);
        void AddGrade(string grade);
    }
}
