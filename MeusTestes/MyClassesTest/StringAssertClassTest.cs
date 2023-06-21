using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("VianA")]
        public void ContainsTest()
        {
            string str1 = "José Viana";
            string str2 = "Viana";

            StringAssert.Contains(str1 , str2);
        }

        [TestMethod]
        [Owner("VianA2")]
        public void StartsWithTest()
        {
            string str1 = "Todos Caixa Alta";
            string str2 = "Todos Caixa";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("VianA3")]
        public void IsAllLoweCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("todos caixa", reg);
        }



        [TestMethod]
        [Owner("VianA4")]
        public void IsNotAllLoweCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Todos caixa", reg);
        }

    }
}
