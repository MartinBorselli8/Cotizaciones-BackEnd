using contrato.entidades;
using contrato.servicios.Client;
using contrato.servicios.Product;
using contrato.servicios.Product.Request;
using contrato.servicios.Quote;
using contrato.servicios.Quote.Request;
using contrato.servicios.Quote.Response;
using dominio;
using dominio.entidades;
using dominio.infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace servicio
{
    public class QuotesService : IQuotesService
    {
        private readonly IRepositorio<Quotes> _repositorioQuotes;
        private readonly IRepositorio<dominio.entidades.QuotesProducts> _repositorioQuotesProducts;
        private readonly IRepositorio<Clients> _repositorioClient;
        private readonly IProductService _ProductService;
        //private readonly IClientService _ClientService;

        public QuotesService(IRepositorio<Quotes> repositorio, IRepositorio<dominio.entidades.QuotesProducts> repositorioQuotesProduct, IProductService productService, IRepositorio<Clients> repositorioClients)
        {
            this._repositorioQuotes = repositorio;
            this._repositorioQuotesProducts = repositorioQuotesProduct;
            this._ProductService = productService;
            this._repositorioClient = repositorioClients;
        }

        public async Task<DeleteQuoteResponse> Delete(DeleteQuoteRequest request)
        {
            var response = new DeleteQuoteResponse();
            var predicate = CrearPredicado.Verdadero<dominio.entidades.Quotes>();
            if (request.Id > 0) predicate = predicate.Y(c => c.Id == request.Id);
            var QuoteToRemove = await _repositorioQuotes.Buscar(predicate);

            await _repositorioQuotes.Eliminar(QuoteToRemove.FirstOrDefault());

            response.Status = true;
            return response;
        }

        public async Task<DeleteQuotesProductsResponse> DeleteQuotesProducts(DeleteQuotesProductsRequest request)
        {
            var response = new DeleteQuotesProductsResponse();
            var predicate = CrearPredicado.Verdadero<dominio.entidades.QuotesProducts>();
            if (request.Id > 0) predicate = predicate.Y(c => c.Id == request.Id);
            var QuoteProductToRemove = await _repositorioQuotesProducts.Buscar(predicate);

            await _repositorioQuotesProducts.Eliminar(QuoteProductToRemove.FirstOrDefault());

            response.Status = true;
            return response;
        }

        public Task<EditQuoteResponse> Edit(EditQuotesRequest request)
        {

            throw new NotImplementedException();
        }

        public Task<EditQuotesProductsResponse> EditQuotesProducts(EditQuotesProductsRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GetQuotesResponse> Get(GetQuotesRequest request)
        {
            var response = new GetQuotesResponse();
            response.Quotes = new List<QuoteForShow>();
            var repositoryResponse = await _repositorioQuotes.Buscar(CreatePredicate(request));
            var clients = await _repositorioClient.BuscarTodos();

            foreach (var quote in repositoryResponse)
            {
                var quoteForShow = new QuoteForShow();
                quoteForShow.Id = quote.Id;
                quoteForShow.CreateDate = quote.CreateDate;
                quoteForShow.ExpirationDate = quote.ExpirationDate;
                quoteForShow.Price = quote.Price;
                quoteForShow.Condition = quote.Condition;
                foreach (var client in clients)
                {
                    if (client.Id == quote.IdClient)
                    {
                        quoteForShow.Client = client.Name + " " + client.LastName;
                        response.Quotes.Add(quoteForShow);
                        break;
                    }
                }
            }
            return response;
        }

        public async Task<GetQuotesResponse> GetAllQuotes()
        {
            var response = new GetQuotesResponse();
            response.Quotes = new List<QuoteForShow>();
            var quotes = await _repositorioQuotes.BuscarTodos();
            var clients = await _repositorioClient.BuscarTodos();
            

            foreach (var quote in quotes)
            {
                var quoteForShow = new QuoteForShow();
                quoteForShow.Id = quote.Id;
                quoteForShow.CreateDate = quote.CreateDate;
                quoteForShow.ExpirationDate = quote.ExpirationDate;
                quoteForShow.Price = quote.Price;
                quoteForShow.Condition = quote.Condition;
                foreach (var client in clients)
                {
                    if(client.Id == quote.IdClient)
                    {
                        quoteForShow.Client = client.Name + " " + client.LastName;
                        response.Quotes.Add(quoteForShow);
                        break;
                    }
                }
            }
            return response;
        }

        public async Task<GetQuotesProductsResponse> GetQuotesProducts(GetQuotesProductsRequest request)
        {
            var response = new GetQuotesProductsResponse();
            var predicate = CrearPredicado.Verdadero<dominio.entidades.QuotesProducts>();
            if (request.IdQuote > 0) predicate = predicate.Y(c => c.IdQuote == request.IdQuote);
            var repositoryResponse = await _repositorioQuotesProducts.Buscar(predicate);
            response.quotesProducts = repositoryResponse.Select(c => new contrato.entidades.QuotesProducts
            {
                IdQuote = c.IdQuote,
                Amount = c.Amount,
                IdProduct = c.IdProduct
            }).ToList();

            return response;
        }

        public async Task<CreateQuotesResponse> Put(CreateQuotesRequest request)
        {
            var response = new CreateQuotesResponse();
            var QPList = new List<dominio.entidades.QuotesProducts>();
            var QuotesList = await _repositorioQuotes.BuscarTodos();

            if (QuotesList.LastOrDefault().Condition == "Cargando Productos")
            {
                var Quote = await _repositorioQuotes.Obtener(QuotesList.LastOrDefault().Id);
                if (Quote != null)
                {
                    Quote.CreateDate = DateTime.Now;
                    Quote.ExpirationDate = Quote.CreateDate.AddDays(30);
                    Quote.IdClient = request.IdClient;
                    Quote.Condition = "Pendiente";

                    var predicate = CrearPredicado.Verdadero<dominio.entidades.QuotesProducts>();
                    if (QuotesList.LastOrDefault().Id > 0) predicate = predicate.Y(c => c.IdQuote == QuotesList.LastOrDefault().Id);
                    QPList = await _repositorioQuotesProducts.Buscar(predicate);

                    Quote.Price = await TotalPrice(QPList);
                    await _repositorioQuotes.Actualizar(Quote);
                    response.Status = true;
                }
                else
                {
                    return null;
                }
            }

            return response;
        }

        public async Task<CreateQuotesProductsResponse> PostQuotesProducts(CreateQuotesProductsRequest request)
        {
            var response = new CreateQuotesProductsResponse();
            int lastQuoteId;
            var Quotes = await _repositorioQuotes.BuscarTodos();
            if (Quotes.Count == 0)
            {

                await _repositorioQuotes.Crear(new Quotes
                {
                    IdClient = 1,
                    Condition = "Cargando Productos"
                });

                var newQuotes = await _repositorioQuotes.BuscarTodos();
                lastQuoteId = newQuotes.LastOrDefault().Id;


            }
            else if (Quotes.LastOrDefault().Condition != "Cargando Productos")
            {
                await _repositorioQuotes.Crear(new Quotes
                {
                    IdClient = 1,
                    Condition = "Cargando Productos"
                });
                var newQuotes = await _repositorioQuotes.BuscarTodos();
                lastQuoteId = newQuotes.LastOrDefault().Id;
            }
            else
            {
                lastQuoteId = Quotes.LastOrDefault().Id;
            }

            var newQuoteProducts = new dominio.entidades.QuotesProducts();
            newQuoteProducts.IdProduct = request.IdProduct;
            newQuoteProducts.Amount = request.Amount;
            newQuoteProducts.IdQuote = lastQuoteId;
            await _repositorioQuotesProducts.Crear(newQuoteProducts);

            response.Status = true;
            return response;
        }

        private Expression<Func<dominio.entidades.Quotes, bool>> CreatePredicate(GetQuotesRequest request)
        {
            var predicate = CrearPredicado.Verdadero<dominio.entidades.Quotes>();

            if (request.IdClient > 0) predicate = predicate.Y(c => c.IdClient == request.IdClient);
            if (request.Id > 0) predicate = predicate.Y(c => c.Id == request.Id);
            if (request.DateTo != null && request.DateFrom != null)
            {
                predicate = predicate.Y(x => x.CreateDate >= Convert.ToDateTime(request.DateFrom) && x.CreateDate <= Convert.ToDateTime(request.DateTo));
            }
            //if(request.Condition != null)
            //{
            //    if(request.Condition == "")
            //    {
            //        predicate = predicate.Y(X => X.isConfirmed == 1);
            //    }
            //    else
            //    {
            //        predicate = predicate.Y(X => X.isConfirmed == 0);
            //    }
            //}

            return predicate;
        }

        private async Task<decimal> TotalPrice(List<dominio.entidades.QuotesProducts> QPList)
        {
            decimal Response = 0;
            var request = new GetProductRequest();
            var responseService = await _ProductService.getProducts(request);

            var productList = responseService.Products.Select(p => new contrato.entidades.Product
            {
                Id = p.Id,
                UnitPrice = p.UnitPrice,
                Description = p.Description
            }).ToList();

            foreach (var qp in QPList)
            {
                foreach (var p in productList)
                {
                    if (p.Id == qp.IdProduct)
                    {
                        Response = Response + (p.UnitPrice * qp.Amount);
                        break;
                    }
                }
            }


            return Response;
        }

        public async Task<ConfirmQuoteResponse> ConfirmQuote(ConfirmQuoteRequest request)
        {
            var response = new ConfirmQuoteResponse();
            var QuoteToConfirm = await _repositorioQuotes.Obtener(request.Id);

            if(QuoteToConfirm?.Condition == "Pendiente")
            {
                QuoteToConfirm.Condition = "Confirmado";
                await _repositorioQuotes.Actualizar(QuoteToConfirm);
                response.Status = true;
                return response;
            }
            else
            {
                response.Status = false;
                return response;
            }

        }
    }
}
