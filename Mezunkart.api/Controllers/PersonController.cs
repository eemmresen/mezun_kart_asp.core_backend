using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mezun_Karti.Business.Abstract;
using Mezun_Karti.DataAccess;
using Mezun_Karti.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mezunkart.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IPersonService _personService;
        private MezünKartDbContext db = new MezünKartDbContext();

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public  ActionResult GetAllPersonel()
        {
            var veri = db.persons.ToList();
            
            return Ok(veri);



        }
        

        [HttpPost]
        public async Task<IActionResult> createPerson(person Person)
        {
            var session_user_email = HttpContext.Session.GetString("username");

            if (session_user_email != null)
            {

                await _personService.createPerson(Person);
                return Ok(Person);
            }
            else
            {
                return NotFound();
            }


           
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var session_user_email = HttpContext.Session.GetString("username");

            if (session_user_email != null)
            {
                if (await _personService.GetPersonById(id) != null)
                {
                     await _personService.DeletePerson(id);
                     return Ok();
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
       // [Route("[Action]/{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var session_user_email = HttpContext.Session.GetString("username");

            if (session_user_email != null)
            {

               var per= await _personService.GetPersonById(id);
                return Ok(per);
            }
            else
            {
                return NotFound();
            }
        }

        //public async Task<IActionResult> GetPersonByName(string name)
        //{
        //    return _PersonRepository.GetPersonByName(name);
        //}


        [HttpPut]
        public async Task<IActionResult> update(person Person)
        {
            var session_user_email = HttpContext.Session.GetString("username");

            if (session_user_email != null)
            {

                if (await _personService.GetPersonById(Person.id) != null)
                {
                    await _personService.updatePerson(Person);
                    return Ok(Person);
                }
                return NotFound();

               
            }
            else
            {
                return NotFound();
            }
        }
    }
}