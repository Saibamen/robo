using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChellengeApp
{
    public class EmployeeInMemory : EmployeeBase
    {
        public delegate string WriteMessage(string message);  // to alias to metody
        public delegate void WriteMessage2(string message);  // to alias to metody
        public delegate void WriteMessage3(string message);  // to alias to metody

        private List<float> grades = new List<float>();
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public char Sex { get; private set; }
        public int Age { get; private set; }
        public string NameFather { get; private set; }
        public EmployeeInMemory(string name, string surname, char sex, int age, string nameFather) : base(name, surname, sex, age, nameFather)
        {

            WriteMessage del;
            del = ReturnMessage;
            del("Tekst testowy");               //obie metody są jednznaczne
            ReturnMessage("Tekst testowy");
            var result1 = del("Tekst testowy1");
            var result2 = ReturnMessage("Tekst testowy2");

            WriteMessage2 del2;
            del2 = WriteMessageInConsole;
            del2("Tekst testowy void 1");
            WriteMessageInConsole("Tekst testowy void 2");

            WriteMessage2 del3;
            del3 = WriteMessageInConsole;
            del3 += WriteMessageInConsole2;
            del3("Tekst testowy suma delegatów");

            del3 -= WriteMessageInConsole;
            del3("DUPA JASIU Tekst testowy suma delegatów");
        }


        private string ReturnMessage(string message)
        {
            return message;
        }

        private void WriteMessageInConsole(string message)
        {
            Console.WriteLine(message);
        }
        private void WriteMessageInConsole2(string message)
        {
            Console.WriteLine(message.ToUpper());
        }


        public override void SayHello()         //nadpisanie metody wirtualnej
        {
            Console.WriteLine("Cześć");         //to z tej klasy
            base.SayHello();                    //to z klasy bazowej
        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new Exception("Podano błędną ocenę, dopuszczalny zakres: 0-100");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                if (result >= float.MinValue && result <= float.MaxValue)
                {
                    AddGrade((float)result);
                }
                else
                {
                    throw new Exception("Podano zby dużą liczbę dla typu float");
                }
            }
            else
            {
                switch (grade)     //symulacja obsługi typu char
                {
                    case "A":
                        AddGrade(100);
                        break;
                    case "B":
                        AddGrade(80);
                        break;
                    case "C":
                        AddGrade(60);
                        break;
                    case "D":
                        AddGrade(40);
                        break;
                    case "E":
                        AddGrade(20);
                        break;
                    default:
                        throw new Exception("Podano błędną ocenę, dopuszczalne wartości?: A-E");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;
            statistics.Average = 0;

            foreach (var grade in grades)
            {
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Average += grade;
            }

            if (grades.Count != 0)
            {
                Math.Round((statistics.Average /= grades.Count), 2);

                switch (statistics.Average)
                {
                    case var average when average >= 80:
                        statistics.AverageLetter = 'A';
                        break;
                    case var average when average >= 60:
                        statistics.AverageLetter = 'B';
                        break;
                    case var average when average >= 40:
                        statistics.AverageLetter = 'C';
                        break;
                    case var average when average >= 20:
                        statistics.AverageLetter = 'D';
                        break;
                    default:
                        statistics.AverageLetter = 'E';
                        break;
                }
            }
            else
            {
                statistics.Max = 0;
                statistics.Min = 0;
                statistics.AverageLetter = 'z';
            }
            return statistics;
        }
    }
}

