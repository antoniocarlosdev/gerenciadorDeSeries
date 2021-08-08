using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Core.Service.AuthService.Models
{
    public class  ApplicationRole
    {
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }

        public string Token { get; internal set; }
        public double ExpireAt { get; set; }
        public DateTime ExpireDate { get; set; }
    }
    public class TokenJson
    {
        public string Secret { get { return "TokenAuthData"; } }
    }
}
