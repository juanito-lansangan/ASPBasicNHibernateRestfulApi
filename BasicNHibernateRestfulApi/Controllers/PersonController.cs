using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasicNHibernateRestfulApi.Models;

namespace BasicNHibernateRestfulApi.Controllers
{
    public class PersonController : ApiController
    {
        private IPersonRepository repository;

        public PersonController()
        {
            this.repository = new PersonRepository();
        }

        // GET api/person
        public IEnumerable<Person> Get()
        {
            return repository.GetAll();
        }

        // GET api/person/5
        public Person Get(int Id)
        {
            return repository.GetById(Id);
        }

        // POST api/person
        public void Post([FromBody]Person person)
        {
            this.repository.Add(person);
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]Person person)
        {
            person.Id = id;
            this.repository.Update(person);
        }

        // DELETE api/person/5
        public void Delete(int Id)
        {
            Person person = this.repository.GetById(Id);
            this.repository.Remove(person);
        }
    }
}
