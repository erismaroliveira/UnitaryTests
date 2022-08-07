using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("ErismarO")]
        public void ContainsTest()
        {
            string str1 = "Erismar Oliveira";
            string str2 = "Oliveira";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void StartsWithTest()
        {
            string str1 = "Todos Caixa Alta";
            string str2 = "Todos Caixa";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa", reg);
        }

        [TestMethod]
        [Owner("ErismarO")]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos caixa", reg);
        }
    }
}
