using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contrato.servicios.Auth
{
    public interface IAuthService
    {
        Task<Response.AuthLoginResponse> LoginRequestQuery(Request.AuthLoginRequest request);

        Task<Response.AuthLoginResponse> NewUserRegister(Request.AuthLoginRequest request);
    }
}
