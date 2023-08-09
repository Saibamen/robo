using ChellengeApp;
using System.Diagnostics;

while (true)
{
    Console.Clear();
    Console.WriteLine(" Witamy w programie do obsługi oceny Pracowników i Kierowników");
    Console.WriteLine("*************************************************");
    Console.WriteLine();
    Console.WriteLine("użycie 'q' powoduje zakończenie wprowadzania");
    Console.WriteLine("Oceny można wprowadzać zarówno literowo 'A-E' jak i liczbowo 0-100, Kierownicy oceny 1-6");

    Console.WriteLine();
    Console.WriteLine("Dane pracownika:");
    Console.Write("Imię \t\t");
    string name = Console.ReadLine().Trim();

    if (name == "q" || name == "Q")
    {
        break;
    }

    Console.Write("Nazwisko \t");
    string surname = Console.ReadLine().Trim();
    if (surname == "q" || surname == "Q")
    {
        break;
    }
    Console.WriteLine($"Każdą ocenę zatwierdź, 'q-quit' koniec wprowadzania punktacji");

    var employee = new EmployeeInMemory(name, surname, 'M', 56);

    employee.GradeAdded += EmployeeGradeAdded;
    void EmployeeGradeAdded(object sender, EventArgs arg)
    {
        Console.WriteLine("Dodano nową ocenę");
    }

    while (true)
    {
        //Console.WriteLine($"Podaj ilość punktów, 'q-quit' koniec wprowadzania punktacji");
        var input = Console.ReadLine().ToUpper().Trim();
        if (input == "Q")
        {
            break;
        }

        try
        {
            employee.AddGrade(input);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
    }
    var statistics = employee.GetStatistics();
    Console.WriteLine($"Wyniki dla: {employee.Name} {employee.Surname}, '{employee.Sex}' lat: {employee.Age}");
    Console.WriteLine($"Min: {statistics.Min:N2} \tMax: {statistics.Max:N2} \tŚrednia: {statistics.Average:N2} \tOgólna ocena: {statistics.AverageLetter}");
    Console.WriteLine();
    Console.WriteLine("zakończono wyświetlanie statystyk Pracownika, wciśnij dowolny klawisz, aby przejść do wprowadzania kolejnego pracownika");
    Console.ReadKey();
}