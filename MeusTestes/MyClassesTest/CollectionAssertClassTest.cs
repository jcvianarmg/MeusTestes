using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("VianA")]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
           PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Antonio", LastName = "Andrade" });
            peopleExpected.Add(new Person() { FirstName = "laura"   , LastName ="Antonia"});
            peopleExpected.Add(new Person() { FirstName = "Thiago"  , LastName ="Paulo"});

            peopleActual = peopleExpected;
            CollectionAssert.AreEqual(peopleExpected, peopleActual);       
        }


        [TestMethod]
        [Owner("VianA")]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Antonio", LastName = "Andrade" });
            peopleExpected.Add(new Person() { FirstName = "laura", LastName = "Antonia" });
            peopleExpected.Add(new Person() { FirstName = "Thiago", LastName = "Paulo" });

            peopleActual = peopleExpected;

            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x,y) => 
                x.FirstName == y.FirstName  && x.LastName == y.Lastname ? 0 : 1));
        }

        [TestMethod]
        [Owner("VianA")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            
            peopleActual = PerMgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }
        [TestMethod]
        [Owner("VianA")]
        public void IsCollectionTypeTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = PerMgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

    }
}
