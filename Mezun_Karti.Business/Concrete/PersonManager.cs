using Mezun_Karti.Business.Abstract;
using Mezun_Karti.DataAccess.Abstract;
using Mezun_Karti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.Business.Concrete
{
   public class PersonManager : IPersonService
    {
        private IPersonRepository _PersonRepository;

        public PersonManager(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }


        public Task<person> createPerson(person Person)
        {
            return  _PersonRepository.createPerson(Person);
        }

        public Task DeletePerson(int id)
        {
            return _PersonRepository.DeletePerson(id);
        }

        public Task<List<person>> GetAllPerson()
        {
            return _PersonRepository.GetAllPerson();
        }

        public Task<person> GetPersonById(int id)
        {
            return _PersonRepository.GetPersonById(id);
        }

        public Task<person> GetPersonByName(string name)
        {
            return _PersonRepository.GetPersonByName(name);
        }

        public Task<person> updatePerson(person Person)
        {
            return _PersonRepository.updatePerson(Person);
        }
    }
}
