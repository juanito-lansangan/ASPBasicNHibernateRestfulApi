using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicNHibernateRestfulApi.Models
{
    public class PersonRepository : IPersonRepository
    {
        public ICollection<Person> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var persons = session
                    .CreateCriteria(typeof(Person))
                    .List<Person>();
                return persons;
            }
        }

        public void Add(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(person);
                transaction.Commit();
            }
        }

        public void Update(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(person);
                transaction.Commit();
            }
        }

        public void Remove(Person person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(person);
                transaction.Commit();
            }
        }

        public Person GetById(int Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Person>(Id);
        }
        
    }
}