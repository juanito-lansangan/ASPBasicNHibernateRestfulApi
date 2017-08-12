using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicNHibernateRestfulApi.Models
{
    public interface IPersonRepository
    {
        ICollection<Person> GetAll();
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
        Person GetById(int Id);
    }
}
