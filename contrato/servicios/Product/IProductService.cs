﻿using contrato.servicios.Product.Request;
using contrato.servicios.Product.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contrato.servicios.Product
{

    public interface IProductService
    {
        Task<GetProductResponse> getProducts(GetProductRequest request);
    }
}
