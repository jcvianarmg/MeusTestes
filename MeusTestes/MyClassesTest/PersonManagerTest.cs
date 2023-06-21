using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Nogueira")]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager PerMgr = new PersonManager();
            Person per;

            per = PerMgr.CreatePerson("José", "Nogueira", false);

            Assert.IsInstanceOfType(per, typeof(Employee));

        }


        [TestMethod]
        [Owner("Nogueira")]
        public void DoEmployeeExistsTest()
        {
            Supervisor super = new Supervisor();
  
            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee()
            {
                FirstName = "Nogueira",
                Lastname = "Viana"


            });

            Assert.IsTrue(super.Employees.Count > 0);

        }
    }
}
