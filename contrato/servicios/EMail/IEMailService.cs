using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.EMail
{
    public interface IEMailService
    {
        public string sendMail(string to, string asunto, string body);
    }
}
