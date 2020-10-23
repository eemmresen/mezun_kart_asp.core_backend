using Mezun_Karti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.Business.Abstract
{
    public interface IPersonService
    {
        Task<List<person>> GetAllPerson();

        Task<person> GetPersonById(int id);

        Task<person> GetPersonByName(string name);

        Task<person> createPerson(person Person);

        Task<person> updatePerson(person Person);

        Task DeletePerson(int id);
    }
}
