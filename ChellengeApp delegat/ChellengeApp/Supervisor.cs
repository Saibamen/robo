using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChellengeApp
{
    public class Supervisor : IEmployee
    {
        private List<float> grades = new List<float>();
        public Supervisor(string name, string surname) //: this('M', 56, "Franciszek")
        {
        }

        public Supervisor(string name, string surname, char sex, int age, string nameFather)// : base (name, surname, sex, age, nameFather)
        {
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public char Sex { get; private set; }
        public int Age { get; private set; }
        public string NameFather { get; private set; }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new Exception("Podano błędną daną z poza zakresu 0-100");
            }
        }

        public void AddGrade(string grade)
        {
            grade = grade.Replace("+", "").Trim();
            if (grade.Length == 2 && grade[1] == '-')
            {
                grade = "-" + grade.Substring(0, 1);
            }
            if (int.TryParse(grade, out int note))
            {
                switch (note)
                {
                    case 6:
                        grades.Add(100);
                        break;
                    case 5:
                        grades.Add(80);
                        break;
                    case 4:
                        grades.Add(60);
                        break;
                    case 3:
                        grades.Add(40);
                        break;
                    case -3:
                        grades.Add(35);
                        break;
                    case 2:
                        grades.Add(25);
                        break;
                    case -2:
                        grades.Add(20);
                        break;
                    case 1:
                        grades.Add(0);
                        break;
                    default:
                        throw new Exception("Podano błędną ocenę, oczekuje się ocen z zakresu 1-6");
                }
            }
            else
            {
                throw new Exception("Podano błędną ocenę, oczekuje się ocen z zakresu 1-6");
            }
        }
        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    grades.Add(100);
                    break;
                case 'B':
                case 'b':
                    grades.Add(80);
                    break;
                case 'C':
                case 'c':
                    grades.Add(60);
                    break;
                case 'D':
                case 'd':
                    grades.Add(40);
                    break;
                case 'E':
                case 'e':
                    grades.Add(20);
                    break;
                default:
                    throw new Exception("Podano niewłaściwą wartość z zakresu A-E");
            }
        }

        public Statistics GetStatistics()
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
