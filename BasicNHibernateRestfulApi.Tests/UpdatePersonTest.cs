using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicNHibernateRestfulApi.Models;
using NHibernate;

namespace BasicNHibernateRestfulApi.Tests
{
    [TestClass]
    public class UpdatePersonTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPersonRepository repository = new PersonRepository();
            var person = repository.GetById(1);
            person.FirstName = "Juan";
            person.LastName = "Lansangan";
            person.PayRate = 50000;
            person.StartDate = DateTime.Parse("1/22/2011");
            person.EndDate = DateTime.Parse("9/22/2016");
            repository.Update(person);

            // use session to try to load the product
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var fromDb = session.Get<Person>(person.Id);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(person, fromDb);
                Assert.AreEqual(person.FirstName, fromDb.FirstName);
                Assert.AreEqual(person.LastName, fromDb.LastName);
                Assert.AreEqual(person.PayRate, fromDb.PayRate);
                Assert.AreEqual(person.StartDate, fromDb.StartDate);
                Assert.AreEqual(person.EndDate, fromDb.EndDate);
            }
        }
    }
}
