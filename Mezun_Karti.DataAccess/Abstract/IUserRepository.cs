using Mezun_Karti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<user> login(user User);
        
    }
}
