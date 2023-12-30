

using PersonApp;

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person( "John", "Doe", new DateTime(1990, 5, 15)),
            new Person( "Jane", "Smith", new DateTime(1985, 10, 20)),
            new Person( "Amir", "Olimov", new DateTime(1987, 01, 13)),

            
            // Добавьте еще записей при необходимости
        };

        string filePath = "people.txt";

        // Запись данных в файл
        WriteToFile(people, filePath);

        // Чтение данных из файла и вывод на консоль
        List<Person> readPeople = ReadFromFile(filePath);
        foreach (var person in readPeople)
        {
            Console.WriteLine(person);
        }
    }

    static void WriteToFile(List<Person> people, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var person in people)
                {
                    writer.WriteLine($"{person.Id} {person.Name} {person.LastName} {person.Birthday.ToShortDateString()}");
                }
            }

            Console.WriteLine($"Данные успешно записаны в файл: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }

    static List<Person> ReadFromFile(string filePath)
    {
        List<Person> people = new List<Person>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length == 4)
                    {
                        string id = (parts[0]);
                        string name = parts[1];
                        string lastName = parts[2];
                        DateTime birthday = DateTime.Parse(parts[3]);
                        people.Add(new Person(name, lastName, birthday));
                    }
                }
            }

            Console.WriteLine($"Данные успешно прочитаны из файла: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении из файла: {ex.Message}");
        }

        return people;
    }

    
}