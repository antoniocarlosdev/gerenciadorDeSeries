using Gerenciador.Core.Service.AuthService;
using Gerenciador.Core.Service.AuthService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador.Api.Controllers
{
    [ApiController]
    public class AuthUserController : Controller
    {
        private IAuthService _authService;

        public AuthUserController(IAuthService IAuthService)
        {
            _authService = IAuthService;
        }
        [AllowAnonymous]
        [HttpPost("/connect/token"), Produces("application/json")]
        public dynamic Connect([FromBody] Signin request)
        {
            var user = _authService.AuthenticateWebExample(request.Username, request.Password);
            if (user == null)
                return BadRequest(new { message = "Usuario Ou Senha Incorreto" });
            return Json(new
            {
                userName = user.UserName,
                token = user.Token,
                expireAt = user.ExpireAt,
                expireDate = user.ExpireDate,
            });
        }
        [AllowAnonymous]
        [HttpPost("add-user"), Produces("application/json")]
        public void AddUser([FromBody] Signin request)
        {
           _authService.AddUser(request.Username, request.Password);
        }
    }
}
