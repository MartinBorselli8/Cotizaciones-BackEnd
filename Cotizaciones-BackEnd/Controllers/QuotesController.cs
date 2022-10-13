using contrato.servicios.Quote;
using contrato.servicios.Quote.Request;
using contrato.servicios.Quote.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizaciones_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : Controller
    {
        private readonly IQuotesService _QuotesService;
        public QuotesController(IQuotesService QuotesService)
        {
            _QuotesService = QuotesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetQuotesRequest request)
        {
            var response = new GetQuotesResponse();
            var ItsUpdated = await _QuotesService.UpdateExpiredQuotes();
            if (ItsUpdated)
            {
                response = await _QuotesService.Get(request);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("getAllQuotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            var response = await _QuotesService.GetAllQuotes();
            return Ok(response);
        }

        [HttpGet]
        [Route("getQuotesProducts")]
        public async Task<IActionResult> GetQuotesProducts([FromQuery] GetQuotesProductsRequest request)
        {
            var response = await _QuotesService.GetQuotesProducts(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("getQuotesProductsForStatitics")]
        public List<int> getQuotesProductsForStatitics()
        {
            var response = new List<int>();

            response.Add(5);
            response.Add(4);
            response.Add(7);
            response.Add(1);
            response.Add(3);
            response.Add(2);
            
            return response;
        }



        [HttpGet]
        [Route("getQuotesProductsForCreateQuote")]
        public async Task<IActionResult> GetQuotesProductsForCreateQuote([FromQuery] GetQuotesProductsForShowRequest request)
        {
            var response = await _QuotesService.GetQuotesProductsForShow(request);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> Put([FromQuery] CreateQuotesRequest request)
        {
            var response = await _QuotesService.Put(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("ConfirmQuote")]
        public async Task<IActionResult> Put([FromQuery] ConfirmQuoteRequest request)
        {
            var response = await _QuotesService.ConfirmQuote(request);
            return Ok(response);
        }


        [HttpPost]
        [Route("postQuotesProducts")]
        public async Task<IActionResult> PostQuotesProducts([FromQuery] CreateQuotesProductsRequest request)
        {
            var response = await _QuotesService.PostQuotesProducts(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteQuoteRequest request)
        {
            var response = await _QuotesService.Delete(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteQuotesProducts")]
        public async Task<IActionResult> DeleteQuotesProducts([FromQuery] DeleteQuotesProductsRequest request)
        {
            var response = await _QuotesService.DeleteQuotesProducts(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("editQuoteProduct")]
        public async Task<IActionResult> EditQuoteProduct([FromQuery] EditQuotesProductsRequest request)
        {
            var response = await _QuotesService.EditQuotesProducts(request);
            return Ok(response);
        }


        [HttpPut]
        [Route("editQuote")]
        public async Task<IActionResult> EditQuote([FromQuery] EditQuotesRequest request)
        {
            var response = await _QuotesService.EditQuotes(request);
            return Ok(response);
        }
    }
}
