using Mezun_Karti.DataAccess.Abstract;
using Mezun_Karti.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.DataAccess.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        
        public async Task<person> createPerson(person Person)
        {
            using (var personDbContext = new MezünKartDbContext())
            {

                await personDbContext.persons.AddAsync(Person);
                await personDbContext.SaveChangesAsync();
                return Person;
            }
        }

        public async Task DeletePerson(int id)
        {
            using (var personDbContext = new MezünKartDbContext())
            {
                var deleteperson = await GetPersonById(id);
                personDbContext.persons.Remove(deleteperson);
                await personDbContext.SaveChangesAsync();
            
            }
        }

        public async Task<List<person>> GetAllPerson()
        {
            using (var personDbContext = new MezünKartDbContext())
            {

                return await personDbContext.persons.ToListAsync();
            }
        }

        public async Task<person> GetPersonById(int id)
        {
            using (var personDbContext = new MezünKartDbContext())
            {
                return await personDbContext.persons.FindAsync(id);

            }
        }

        public async Task<person> GetPersonByName(string name)
        {
            using (var personDbContext = new MezünKartDbContext())
            {
                return await personDbContext.persons.FirstOrDefaultAsync(x => x.name.ToLower() == name.ToLower());

            }
        }

        public async Task<person> updatePerson(person Person)
        {
            using (var personDbContext = new MezünKartDbContext())
            {
                  personDbContext.persons.Update(Person);
                  await personDbContext.SaveChangesAsync();
                  return Person;

            }
        }
    }
}
