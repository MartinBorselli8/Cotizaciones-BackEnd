using contrato.servicios.Statitics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatiticsController : Controller
    {

        private readonly IStatiticsService _StatiticsService;

        public StatiticsController(IStatiticsService StatiticsService)
        {
            _StatiticsService = StatiticsService;
        }

        [HttpGet]
        [Route("getDataForStatitics")]
        public async Task<IActionResult> GetDataForStatitics()
        {
            var response = await _StatiticsService.GetDataForStatitics();
            return Ok(response);
        }
    }
}
