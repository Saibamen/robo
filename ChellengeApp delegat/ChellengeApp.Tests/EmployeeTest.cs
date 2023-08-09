

namespace ChellengeApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenEmployeeCollectFourGrades_ShouldCorrectResult()
        {
            //1. arranege
            var employeeTest = new Employee("Arkadiusz", "Bett");
            employeeTest.AddGrade(2);
            employeeTest.AddGrade(10);
            employeeTest.AddGrade(3);
            employeeTest.AddGrade(10);

            //2. act
            var result = employeeTest.GetStatistics();

            //3. assert
            Assert.That((result.Min, result.Max, result.Average), Is.EqualTo((2, 10, 6.25f)));
        }

        [Test]
        public void WhenEmployeeCollectThreeScoresOneMinus_ShouldCorrectResult()
        {
            var employeeTest = new Employee("Arkadiusz", "Bett");
            employeeTest.AddGrade(2.698f);
            employeeTest.AddGrade(100f);
            employeeTest.AddGrade(14.999f);

            var result = employeeTest.GetStatistics();

            Assert.That((result.Min, result.Max, (float)Math.Round(result.Average,2)), Is.EqualTo((2.698f, 100f, 39.23f)));
        }

        [Test]
        public void WhenEmployeeCollectNullScoress_ShouldCorrectResult()
        {
            var employeeTest = new Employee("Arkadiusz", "Bett");

            var result = employeeTest.GetStatistics();

            Assert.That((result.Min, result.Max, result.Average), Is.EqualTo((0, 0, 0f)));
        }

        [Test]
        public void WhenEmployeeCollectSwitchCharacterScoress_ShouldCorrectResult()
        {
            var employeeTest = new Employee();
            employeeTest.AddGrade("a");
            employeeTest.AddGrade("e");
            employeeTest.AddGrade("B");
            employeeTest.AddGrade("z");
            employeeTest.AddGrade(111);
            employeeTest.AddGrade("A");
            employeeTest.AddGrade("A");
            employeeTest.AddGrade("c");
            employeeTest.AddGrade("E");

            var result = employeeTest.GetStatistics();

            Assert.That((result.Min, result.Max, (float)Math.Round(result.Average, 2)), Is.EqualTo((20f, 100f, 63.33f)));
        }


    }
}