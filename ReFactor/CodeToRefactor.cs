using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor
{
    public class Person
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        public Person(string name) : this(name, Under16.Date)
        {
        }

        public Person(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
        public override string ToString()
        {
            return $"Name: {Name} DOB: {DOB.DateTime.ToShortDateString()}";
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<Person> _people;

        public BirthingUnit()
        {
            _people = new List<Person>();
        }

        /// <summary>
        /// GetPeople
        /// </summary>
        /// <param name="i"></param>
        /// <returns>List<object></returns>
        public List<Person> GetPeople(int i)
        {
            string[] names = new []{ "Bob", "Betty" };
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a Random Name
                    var random = new Random();
                    var name = names[random.Next(0, 1)];
                    
                    // Adds new people to the list
                    _people.Add(new Person(name, DateTime.UtcNow.AddYears(random.Next(18, 85) * -1)));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        public IEnumerable<Person> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB <= DateTime.Now.AddYears(-30)) : _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(Person p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            return $"{p.Name} {lastName}".Substring(0, 255).TrimEnd();
        }
    }
}