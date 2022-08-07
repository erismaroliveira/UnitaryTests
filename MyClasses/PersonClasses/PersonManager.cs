using System;
using System.Collections.Generic;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                    ret = new Supervisor();
                else
                    ret = new Employee();

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Erismar", LastName = "Oliveira" });
            people.Add(new Person() { FirstName = "Natália", LastName = "Nascimento" });
            people.Add(new Person() { FirstName = "Anna", LastName = "Eloah" });
            people.Add(new Person() { FirstName = "Isabella", LastName = "Victoria" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Erismar", "Oliveira", true));
            people.Add(CreatePerson("Natália", "Nascimento", true));
            people.Add(CreatePerson("Anna", "Eloah", true));
            people.Add(CreatePerson("Isabella", "Victoria", true));

            return people;
        }
    }
}
