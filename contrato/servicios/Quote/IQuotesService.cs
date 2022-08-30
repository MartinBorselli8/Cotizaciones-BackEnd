using contrato.servicios.Quote.Request;
using contrato.servicios.Quote.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contrato.servicios.Quote
{
    public interface IQuotesService
    {
        Task<GetQuotesResponse> Get(GetQuotesRequest request);
        Task<GetQuotesResponse> GetAllQuotes();
        Task<GetQuotesProductsResponse> GetQuotesProducts(GetQuotesProductsRequest request);
        Task<GetQuotesProductsForShowResponse> GetQuotesProductsForShow();
        Task<EditQuoteResponse> Edit(EditQuotesRequest request);
        Task<EditQuotesProductsResponse> EditQuotesProducts(EditQuotesProductsRequest request);
        Task<DeleteQuoteResponse> Delete(DeleteQuoteRequest request);
        Task<DeleteQuotesProductsResponse> DeleteQuotesProducts(DeleteQuotesProductsRequest request);
        Task<CreateQuotesResponse> Put(CreateQuotesRequest request);

        Task<ConfirmQuoteResponse> ConfirmQuote(ConfirmQuoteRequest request);

        Task<CreateQuotesProductsResponse> PostQuotesProducts(CreateQuotesProductsRequest request);
    }
}
