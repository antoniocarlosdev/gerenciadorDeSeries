

using Gerenciador.Core.DAL.Models;
using Gerenciador.Core.Service.AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Core.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private DateTime ExpireDate { get => DateTime.UtcNow.AddHours(6); }
        private static List<Access> _accesses = new List<Access>();
        private readonly TokenJson _appSettings;
        public ApplicationRole AuthenticateWebExample(string username, string password)
        {

            var user = FindByUserName(username);
            if (user == null || user.Count() == 0)
                return null;
            var result = CheckPasswordSignInAsync(user, password);
            if (result == null)
                return null;
            result.PasswordHash = null;

            var token = "NoUse";
            result.Token = token;
            result.ExpireDate = ExpireDate;
            result.ExpireAt = ExpireDate.Ticks;
            result.IsAuthenticated = true;
            return result;

        }
        private ApplicationRole CheckPasswordSignInAsync(List<ApplicationRole> users, string password)
        {
            var user = (users.Where(p=> p.PasswordHash == password)).ToList();

            if (user.Count() >0)
                return user.First();
            else
                return null;
        }
        private  List<ApplicationRole> FindByUserName(string userId)
        {
            try
            {
                var accesses = _accesses.Where(p => p.Username == userId).Select(p => new ApplicationRole
                {
                    IsAuthenticated = false,
                    UserName = p.Username,
                    PasswordHash = p.Password,
                }); 
                return accesses.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddUser(string name, string password)
        {
            _accesses.Add(new Access() { Username = name, Password = password });
        }
    }
}
