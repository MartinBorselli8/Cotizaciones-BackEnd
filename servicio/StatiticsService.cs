using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using contrato.servicios.Statitics;
using dominio.entidades;
using dominio.infraestructura;

namespace servicio
{
    public class StatiticsService : IStatiticsService
    {
        private readonly IRepositorio<Quotes> _repositorioQuotes;
        private readonly IRepositorio<dominio.entidades.QuotesProducts> _repositorioQuotesProducts;
        private readonly IRepositorio<Products> _repositorioProducts;

        public StatiticsService(IRepositorio<Quotes> repositorio, IRepositorio<dominio.entidades.QuotesProducts> repositorioQuotesProduct, IRepositorio<Products> repositorioProducts)
        {
            this._repositorioQuotes = repositorio;
            this._repositorioQuotesProducts = repositorioQuotesProduct;
            this._repositorioProducts = repositorioProducts;
        }


        public async Task<GetDataForStatiticsResponse> GetDataForStatitics()
        {
            var response = new GetDataForStatiticsResponse();
            response.QuoteCounts = new List<int>();
            response.ProductNames = new List<string>();
            response.ProductCounts = new List<int>();
            response.QuoteStates = new List<string>();

            var ProductList = await _repositorioProducts.BuscarTodos();
            var QuotesProductList = await _repositorioQuotesProducts.BuscarTodos();
            var QuotesList = await _repositorioQuotes.BuscarTodos();
            int count;
            int Count_Vencido=0;
            int Count_Pendiente=0;
            int Count_Confirmado=0;

            foreach (var p in ProductList)
            {
                count = 0;
                foreach (var QP in QuotesProductList)
                {
                    if (QP.IdProduct == p.Id)
                    {
                        count = count + QP.Amount;
                    }

                }

                response.ProductNames.Add(p.Description);
                response.ProductCounts.Add(count);
            }

            //Instancio la lista de estados de Cotizacion ya que son valores constantes.
            //en la posicion cero va a estar el estado "Confirmado", en la 1 "Pendiente", en la 2 "Vencido".

            response.QuoteStates.Add("Confirmado");
            response.QuoteStates.Add("Pendiente");
            response.QuoteStates.Add("Vencido");

            foreach (var Q in QuotesList)
            {
                switch (Q.Condition)
                {
                    case "Confirmado":
                        Count_Confirmado += 1;
                    break;
                    case "Pendiente":
                        Count_Pendiente += 1;
                        break;
                    case "Vencido":
                        Count_Vencido += 1;
                        break;
                    default:
                        
                    break;
                }

            }

            response.QuoteCounts.Add(Count_Confirmado);
            response.QuoteCounts.Add(Count_Pendiente);
            response.QuoteCounts.Add(Count_Vencido);

            return response;
        }
    }
}
