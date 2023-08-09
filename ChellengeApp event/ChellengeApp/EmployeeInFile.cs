using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChellengeApp
{
    public class EmployeeInFile : EmployeeBase
    {
        private List<float> grades = new List<float>();
        private string name;
        private string surname;
        private const string fileName = "grades.txt";

        public EmployeeInFile(string name, string surname, char sex, int age) : this(name, surname, sex, age , "Franciszek")
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        public EmployeeInFile(string name, string surname, char sex, int age, string nameFather) : base(name, surname, sex, age, nameFather)
        {
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public char Sex { get; private set; }
        public int Age { get; private set; }
        public string NameFather { get; private set; }



        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using (var writer = File.AppendText(fileName))      //otwarcie pliku strumieniowego, trzeba go potem zamknąć
                {
                    writer.WriteLine(grade);                        //dopisanie wiersza
                }
            }
            else
            {
                throw new Exception("Podano błędną daną z poza zakresu 0-100");
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

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    int lineNumber = 0;
                    while (line != null)
                    {
                        lineNumber++;
                        if ((float.TryParse(line, out float result)) && (result >= 0 && result <= 100))
                        {
                            grades.Add((float)result);
                        }
                        else
                        {
                            //throw new Exception("Ktoś grzebał w pliku");
                            Console.WriteLine($"Ktoś grzebał w pliku w linii {lineNumber}: {line}");
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            if (grades.Count != 0)
            {
                foreach (var grade in grades)
                {
                    statistics.Min = Math.Min(statistics.Min, grade);
                    statistics.Max = Math.Max(statistics.Max, grade);
                    statistics.Average += grade;
                }

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
