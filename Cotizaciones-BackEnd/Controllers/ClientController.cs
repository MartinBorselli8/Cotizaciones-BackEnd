using contrato.servicios.Client;
using contrato.servicios.Client.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones_BackEnd.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ClientController : Controller
    {
        // Inyeccion de servicio
        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get( [FromQuery] GetClientRequest request)
        {
            var response = await _ClientService.getClients(request);
            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete( [FromQuery] DeleteClientRequest request)
        {
            var response = await _ClientService.deleteClients(request);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] AddClientRequest request)
        {
            var response = await _ClientService.addClients(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] PutClientRequest request)
        {
            var response = await _ClientService.putClient(request);
            return Ok(response);
        }

    }
}
