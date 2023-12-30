using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp
{
    internal class Person
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string name, string lastName, DateTime birthday)
        {
            
            Name = name;
            LastName = lastName;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {LastName}, {Birthday.ToShortDateString()}";
        }
    }
}
