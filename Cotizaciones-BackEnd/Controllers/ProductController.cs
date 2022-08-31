using contrato.servicios.Client.Request;
using contrato.servicios.Product;
using contrato.servicios.Product.Request;
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
    public class ProductController : Controller
    {
        // Inyeccion de servicio
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductRequest request)
        {
            var response = await _ProductService.getProducts(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductRequest request)
        {
            var response = await _ProductService.deleteProducts(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] PutProductRequest request)
        {
            var response = await _ProductService.putProducts(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] AddProductRequest request)
        {
            var response = await _ProductService.addProducts(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("getProductById")]
        public async Task<IActionResult> GetClientForEdit([FromQuery] GetProductForEditRequest request)
        {
            var response = await _ProductService.getProductsForEdit(request);
            return Ok(response);
        }

    }
}
