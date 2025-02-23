namespace Otus_Homework_12;

internal class Program
{
    private static void Main()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        list = list.Top(30).ToList();

        foreach (var item in list) Console.WriteLine(item);

        var persons = new List<Person>
        {
            new() { Name = "Joe", Age = 20 },
            new() { Name = "Bob", Age = 30 },
            new() { Name = "Jack", Age = 18 },
            new() { Name = "Jill", Age = 25 },
            new() { Name = "Jane", Age = 22 },
            new() { Name = "Jenny", Age = 21 }
        };

        var filteredPersons = persons.Top(20, person => person.Age).ToList();

        foreach (var person in filteredPersons) Console.WriteLine($"{person.Name} - {person.Age}");

        try
        {
            List<string>? nullList = null;
            nullList = nullList?.Top(20).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            var error1 = persons.Top(0, person => person.Age).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            var error2 = persons.Top(999, person => person.Age).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}