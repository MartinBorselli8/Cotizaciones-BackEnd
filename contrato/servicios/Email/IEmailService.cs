using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Email
{
    public interface IEmailService
    {
        public string sendMail(string to, string asunto, string body);
    }
}
