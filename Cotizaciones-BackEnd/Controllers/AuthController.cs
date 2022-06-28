using contrato.servicios.Auth;
using contrato.servicios.Auth.Request;
using contrato.servicios.Auth.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones_BackEnd.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _AuthService;

        public AuthController(IAuthService AuthService)
        {
            _AuthService = AuthService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AuthLoginRequest request)
        {
            var isUserAuthorizated = await _AuthService.LoginRequestQuery(request);
            return Ok(isUserAuthorizated);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthLoginRequest request)
        {
            var isSuccessfullOperation = await _AuthService.NewUserRegister(request);
            return Ok(isSuccessfullOperation);
        }
    }
}
