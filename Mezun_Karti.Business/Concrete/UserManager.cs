using Mezun_Karti.Business.Abstract;
using Mezun_Karti.DataAccess.Abstract;
using Mezun_Karti.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mezun_Karti.Business.Concrete
{
   public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<user> login(user User)
        {
            if (User != null)
            {
                return await _userRepository.login(User);
            }
            else
            {
                throw new Exception("Kullanıcı adı yada şifresi boş olamaz");
            }
           
        }
    }
}
