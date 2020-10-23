using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mezun_Karti.Business.Abstract;
using Mezun_Karti.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;


namespace Mezun_Karti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> login(user User)
        {
            var user = await _userService.login(User);
           

            if (user !=null)
            {
                HttpContext.Session.SetString("username", User.email);
                return Ok();
            }
            return NotFound();
            
        }
    }
}