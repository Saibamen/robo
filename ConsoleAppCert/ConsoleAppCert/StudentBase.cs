﻿namespace ConsoleAppCert
{
    public abstract class StudentBase : Person, IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        internal List<double> grades = new List<double>();

        public StudentBase(string name, string surname, int age) : base(name, surname, age)
        {
        }

        public abstract void AddGrade(double grade);

        public void AddGrade(string grade)
        {
            if (grade == "Q" || grade == "Z") return;

            double addSmallGrade = 0;
            if (grade.Length == 2)
            {
                if (grade.Contains("+"))
                {
                    grade = grade.Replace("+", "");
                    addSmallGrade = 0.50;
                }
                else if (grade.Contains("-"))
                {
                    grade = grade.Replace("-", "");
                    addSmallGrade = -0.25;
                }
            }

            if (double.TryParse(grade, out double result) && result >= double.MinValue && result <= double.MaxValue && Age > 9)
            {
                switch (result)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        AddGrade((double)(result + addSmallGrade));
                        break;
                    default:
                        throw new Exception("\aPodano błędną wartość, dopuszczalne oceny: 1-6");
                        break;
                }
            }
            else if (Age <= 9)
            {
                switch (grade)
                {
                    case "A":
                        AddGrade(6 + addSmallGrade);
                        break;
                    case "B":
                        AddGrade(5 + addSmallGrade);
                        break;
                    case "C":
                        AddGrade(4 + addSmallGrade);
                        break;
                    case "D":
                        AddGrade(3 + addSmallGrade);
                        break;
                    case "E":
                        AddGrade(2 + addSmallGrade);
                        break;
                    case "F":
                        AddGrade(1 + addSmallGrade);
                        break;
                    default:
                        throw new Exception("\aPodano błędną wartość, dopuszczalne oceny: A-E");
                        break;
                }
            }
            else
            {
                throw new Exception("\aWprowadzona ocenę jest z poza dopuszczalnego zakresu");
            }
        }
        public abstract Statistics GetStatistics();
        public void PartialResults()
        {
            Console.WriteLine("oceny cząstkowe: ");
            int index = 0;
            foreach (var item in grades)
            {
                if (index == grades.Count - 1) { Console.Write($"{item:N2}"); }
                else Console.Write($"{item:N2}, ");
                index++;
            }
            Console.WriteLine();
        }
    }
}
