using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("ErismarO")]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("Erismar", "Oliveira", false);

            Assert.IsInstanceOfType(person, typeof(Employee));
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee()
            {
                FirstName = "Erismar",
                LastName = "Oliveira"
            });

            Assert.IsTrue(super.Employees.Count > 0);
        }
    }
}
