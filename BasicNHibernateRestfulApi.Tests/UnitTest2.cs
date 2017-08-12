using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicNHibernateRestfulApi.Models;
using System.Collections.Generic;

namespace BasicNHibernateRestfulApi.Tests
{
    [TestClass]
    public class UnitTest2
    {
        private readonly Person[] _persons = new[]
        {
            new Person {Id = 0, FirstName = "Erica", LastName = "Laxamana"},
            new Person {Id = 1,FirstName = "Juanito", LastName = "Lansangan"},
        };

        [TestMethod]
        public void Can_get_existing_persons()
        {
            IPersonRepository repository = new PersonRepository();
            var fromDb = repository.GetAll();

            Assert.AreEqual(2, fromDb.Count);
            Assert.IsTrue(IsInCollection(_persons[0], fromDb));
            Assert.IsTrue(IsInCollection(_persons[1], fromDb));
        }

        private bool IsInCollection(Person person, ICollection<Person> fromDb)
        {
            foreach (var item in fromDb)
                if (person.Id == item.Id)
                    return true;
            return false;
        }
    }
}
