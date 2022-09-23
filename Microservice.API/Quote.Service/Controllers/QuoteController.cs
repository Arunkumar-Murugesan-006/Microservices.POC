using Event.Hubs.Consumer;
using Event.Hubs.Producer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quote.Service.CQRS.Commands;
using Quote.Service.CQRS.Queries;
using Quote.Service.Models;
using Quote.Service.Services;
using System.Net;

namespace Quote.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly EventProducer eventProducer = new EventProducer();
        private readonly EventConsumer eventConsumer = new EventConsumer();
        private readonly IHttpClientFactoryService _httpClientFactoryService;

        public QuoteController(IMediator mediator, IHttpClientFactoryService httpClientFactoryService)
        {
            this.mediator = mediator;
            _httpClientFactoryService = httpClientFactoryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetQuotes()
        {
            var products = await mediator.Send(new GetAllQuotesQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddQuote([FromBody] QuoteModel quotes)
        {
            var productlist = await _httpClientFactoryService.GetProducts();

            var products = productlist
                    .Where(x => x.Origin == quotes.Origin && x.Destination == quotes.Destination && x.ContainerType == quotes.ContainerType).FirstOrDefault(); ;

            if (products != null)
            {
                quotes.QuotePrice = products.Price * products.Volume;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("This Product not found for Quote Creation.", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                return NotFound();
            }
            await mediator.Send(new AddQuoteCommand(quotes));

            //Produce_Consume_Events("Quote has been added");

            return Ok(quotes);
        }

        /// <summary>
        /// Product and consume event while Add Quotes
        /// </summary>
        /// <param name="comments"></param>
        protected async void Produce_Consume_Events(string comments)
        {
            Task[] tasks = new Task[2];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                eventProducer.Produce_Event(comments).Wait();
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                eventConsumer.Consume_Event().Wait();
            });
            await Task.WhenAll(tasks);
        }
    }
}
