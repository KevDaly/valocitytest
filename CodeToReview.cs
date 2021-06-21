using System;
using System.Collegctions.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    public class People
    {
     private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
     public string Name { get; private set; }
     public DateTimeOffset DOB { get; private set; }
     public People(string name) : this(name, Under16.Date) { }
     public People(string name, DateTime dob) {
         Name = name;
         DOB = dob;
     }}

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    // Typo in the above comment: 'dandon' for 'random' - KD
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                    // Comments from KD:
                    // Getting a date x years in the past can be more concisely done (and hopefully using correct year lengths, whether 365 or 366 days)
                    // (Given that a year has 365 or 366 days, but never 356)
                    // by calling AddYears with a negative number, e.g DateTime.UtcNow.AddYears(random.Next(18, 85) * -1);
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                    // Hopefully the original exception has been logged somewhere before being wrapped - KD
                }
            }
            return _people;
        }
        // This method is not accessible to potential consumer - KD
        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
            // Comments from KD:
            // 30 * 356 is short of 30 years even before leap years are accounted for.
            // The comparison is the wrong way around - it should be x.DOB <= etc.
            // At this point I'd insist on .AddYears(-30)
        }

        public string GetMarried(People p, string lastName)
        {
            if (lastName.Contains("test"))
                return p.Name;
            if ((p.Name.Length + lastName).Length > 255) 
            {
                (p.Name + " " + lastName).Substring(0, 255);
            }
            // Comments from KD:
            // This check doesn't account for the space to be added between names
            // If p.Name + lastName total 255 characters the returned value will be 1 character too long.
            // Also consider allocating a new string p.Name + " " + lastName (or $"{p.Name} {lastName}") before
            // performing the check and using that for subsequent actions - that way the string concatenation doesn't need to be
            // repeated.

            return p.Name + " " + lastName;
        }
    }
}