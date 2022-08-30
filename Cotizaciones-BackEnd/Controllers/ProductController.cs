﻿using contrato.servicios.Product;
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

    }
}