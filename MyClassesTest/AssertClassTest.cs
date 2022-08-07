using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    /// <summary>
    ///  Assert Class for Positive, Negative and Other tests.
    /// </summary>
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("ErismarO")]
        public void AreEqualTest()
        {
            string str1 = "Erismar";
            string str2 = "Erismar";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("ErismarO")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Erismar";
            string str2 = "erismar";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void AreNotEqualTest()
        {
            string str1 = "Erismar";
            string str2 = "Bruce Wayne";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion

        #region AreSame/AreNotSame Tests
        [TestMethod]
        [Owner("ErismarO")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
        #endregion

        #region IsInstanceOfType
        [TestMethod]
        [Owner("ErismarO")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person person;

            person = mgr.CreatePerson("Erismar", "Oliveira", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person person;

            person = mgr.CreatePerson("", "Oliveira", true);

            Assert.IsNull(person);
        }
        #endregion
    }
}
