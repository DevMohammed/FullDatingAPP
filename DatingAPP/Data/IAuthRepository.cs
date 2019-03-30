using DatingAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPP.Data
{
    interface IAuthRepository
    {
        Task<User> Register(User user,string password);
        Task<User> Login(string userName, string password);
        Task<bool> IsUserExists(string userName);



    }
}
