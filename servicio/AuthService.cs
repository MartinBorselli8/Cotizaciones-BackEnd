using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using contrato.servicios.Auth;
using contrato.servicios.Auth.Request;
using contrato.servicios.Auth.Response;
using dominio.infraestructura;
using contrato.entidades;
using System.Linq;
using System.Linq.Expressions;
using dominio.entidades;


namespace servicio
{
    public class AuthService : IAuthService
    {

        private readonly IRepositorio<dominio.entidades.Users> _repositorioAuth;

        public AuthService(IRepositorio<dominio.entidades.Users> repositorioAuth)
        {
            this._repositorioAuth = repositorioAuth;
        }
        public Task<AuthLoginResponse> LoginRequestQuery(AuthLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthLoginResponse> NewUserRegister(AuthLoginRequest request)
        {
            var response = new AuthLoginResponse();

            var NewUser = UserMapping(request);


            await _repositorioAuth.Crear(NewUser);
            response.IsUserAuthorized = true;

            return response;
        }

        private dominio.entidades.Users UserMapping(AuthLoginRequest user)
        {
            var response = new dominio.entidades.Users
            {
                UserName = user.UserName,
                Password = user.Password
            };
            return response;
        }
    }
}
