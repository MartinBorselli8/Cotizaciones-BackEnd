using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Client.Request
{
    public class GetClientRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }

    }
}
