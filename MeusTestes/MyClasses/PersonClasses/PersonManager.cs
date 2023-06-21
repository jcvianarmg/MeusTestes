using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {


        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor) ret = new Supervisor();
                else ret = new Employee();

                ret.FirstName = first;
                ret.Lastname = last;
            }
            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Joaquim", LastName = "Xavier" });
            people.Add(new Person() { FirstName = "laura", LastName = "Antonia" });
            people.Add(new Person() { FirstName = "Thiago", LastName = "Paulo" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Antonio", "Andrade", true));
            people.Add(CreatePerson("laura", "Antonia", true));

            return people;
        }
    } 
}
