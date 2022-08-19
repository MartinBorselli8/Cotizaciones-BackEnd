using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dominio.infraestructura;
using contrato.entidades;
using System.Linq;
using System.Linq.Expressions;
using dominio.entidades;
using contrato.servicios.Product;
using contrato.servicios.Product.Response;
using contrato.servicios.Product.Request;
using dominio;
using datos.Infraestructura;

namespace servicio
{
    public class ProductService : IProductService
    {
        private readonly IRepositorio<Products> _RepositorioProducts;

        public ProductService(IRepositorio<Products> RepositorioProducts)
        {
            _RepositorioProducts = RepositorioProducts;
        }
        public async Task<GetProductResponse> getProducts(GetProductRequest request)
        {
            var response = new GetProductResponse();

            var predicate = CrearPredicado.Verdadero<dominio.entidades.Products>();

            if (request.Description != null) predicate = predicate.Y(c => c.Description == request.Description);
            if (request.UnitPrice > 0) predicate = predicate.Y(c => c.UnitPrice == request.UnitPrice);
           


            var repositoryResponse = await _RepositorioProducts.Buscar(predicate);

            response.Products = repositoryResponse.Select(c => new contrato.entidades.Product
            {
                Id = c.Id,
                Description = c.Description,
                UnitPrice = c.UnitPrice
                

            }).ToList();

            return response;
        }
    }
    
}
