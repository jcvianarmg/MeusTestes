using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {

        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("Jcviana")]
        public void AreEqualTest()
        {
            string str1 = "Jcviana";
            string str2 = "Jcviana";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Jcviana")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSesitiveTest()
        {
            string str1 = "Jcviana";
            string str2 = "jcviana";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Jcviana")]
        public void AreNotEqualTest()
        {
            string str1 = "Jcviana";
            string str2 = "JclaudioViana";

            Assert.AreNotEqual(str1, str2);
        }
        #endregion


        #region AreSame/AreNotSame Tests
        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSame()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion


        #region InstanceOfType test

        [TestMethod]
        [Owner("JCViana")]
        public void InstanceOfType()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("José", "Viana", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("JCVianA")]
        public void InNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Viana", true);

            Assert.IsNull(per);
        }
        #endregion
    }
}
