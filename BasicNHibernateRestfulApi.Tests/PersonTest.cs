using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicNHibernateRestfulApi.Models;
using NHibernate;

namespace BasicNHibernateRestfulApi.Tests
{
    
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Can_add_new_product()
        {
            var person = new Person { FirstName = "Juan", LastName = "Lansangan", PayRate = 50000, StartDate = DateTime.Parse("9/22/2010"), EndDate = DateTime.Parse("6/12/2014") };
            IPersonRepository repository = new PersonRepository();
            Console.WriteLine(person);
            repository.Add(person);

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
