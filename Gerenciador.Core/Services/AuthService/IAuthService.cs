using Gerenciador.Core.Service.AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Core.Service.AuthService
{
    public interface IAuthService
    {
        public ApplicationRole AuthenticateWebExample(string username, string password);
        public void AddUser(string name, string Password);
    }
}
