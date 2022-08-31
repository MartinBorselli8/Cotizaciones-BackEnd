using System;
using System.Collections.Generic;
using System.Text;

namespace contrato.servicios.Client.Response
{
    public class GetClientForEditResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
