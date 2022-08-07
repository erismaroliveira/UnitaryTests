using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("ErismarO")]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Erismar", LastName = "Oliveira" });
            peopleExpected.Add(new Person() { FirstName = "Natália", LastName = "Nascimento" });
            peopleExpected.Add(new Person() { FirstName = "Anna", LastName = "Eloah" });
            peopleExpected.Add(new Person() { FirstName = "Isabella", LastName = "Victoria" });

            // You shall not pass!
            //peopleActual = personManager.GetPeople();

            peopleActual = peopleExpected;

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Erismar", LastName = "Oliveira" });
            peopleExpected.Add(new Person() { FirstName = "Natália", LastName = "Nascimento" });
            peopleExpected.Add(new Person() { FirstName = "Anna", LastName = "Eloah" });
            peopleExpected.Add(new Person() { FirstName = "Isabella", LastName = "Victoria" });

            //You shall not pass!
            peopleActual = personManager.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, 
                Comparer<Person>.Create((x,y) =>
                    x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[3]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}
