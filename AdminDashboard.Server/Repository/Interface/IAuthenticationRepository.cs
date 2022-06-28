using AdminDashboard.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        public Task<bool> Register(RegistrationModel user);
        public Task<bool> Login(LoginModel user);
    }
}
