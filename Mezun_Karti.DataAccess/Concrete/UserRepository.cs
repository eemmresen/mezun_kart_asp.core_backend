using Mezun_Karti.DataAccess.Abstract;
using Mezun_Karti.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<user> login(user User)
        {
            using (var userdb =new MezünKartDbContext())
            {
                user a = new user();
                
              a =  await userdb.users.FirstOrDefaultAsync(y => y.email.ToLower() == User.email.ToLower());

                if (a.email == User.email && a.password == User.password)
                {
                    return a;
                }
                else
                {
                    throw new Exception("Email yada Şifre hatalı");
                }
               
                
            }
        }
    }
}
