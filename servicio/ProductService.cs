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

        public async Task<AddProductResponse> addProducts(AddProductRequest request)
        {
            var response = new AddProductResponse();

            var newProduct = new dominio.entidades.Products
            {
                Description = request.Description,
                UnitPrice = request.UnitPrice
            };

            await _RepositorioProducts.Crear(newProduct);
            response.fueCreado = true;

            return response;
        }

        public async Task<DeleteProductResponse> deleteProducts(DeleteProductRequest request)
        {
            var response = new DeleteProductResponse();

            var ProductToDelete = await _RepositorioProducts.Buscar(c => c.Id == request.Id);

            await _RepositorioProducts.Eliminar(ProductToDelete[0]);

            response.fueEliminado = true;

            return response;
        }

        public async Task<PutProductResponse> putProducts(PutProductRequest request)
        {
            var response = new PutProductResponse();

            var ProductToModify = await _RepositorioProducts.Buscar(c => c.Id == request.Id);

            if (request.Description != null) ProductToModify[0].Description = request.Description;
            if (request.UnitPrice > 0) ProductToModify[0].UnitPrice = request.UnitPrice;

            await _RepositorioProducts.Actualizar(ProductToModify[0]);

            response.fueModificado = true;
            return response;
        }
        public async Task<GetProductForEditResponse> getProductsForEdit(GetProductForEditRequest request)
        {
            var response = new GetProductForEditResponse();

            var ProductToEdit = await _RepositorioProducts.Obtener(request.Id);

            response.Description = ProductToEdit.Description;
            response.UnitPrice = ProductToEdit.UnitPrice;

            return response;

        }

        
    }
    
}
