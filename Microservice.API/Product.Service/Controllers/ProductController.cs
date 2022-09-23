using Event.Hubs.Consumer;
using Event.Hubs.Producer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Service.CQRS.Commands;
using Product.Service.CQRS.Queries;
using Product.Service.Models;

namespace Product.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly EventProducer eventProducer = new EventProducer();
        private readonly EventConsumer eventConsumer = new EventConsumer();

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductModel product)
        {
            await mediator.Send(new AddProductCommand(product));

            Produce_Consume_Events("Product has been added");

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand command)
        {
            command.Product.ProductId = id;
            await mediator.Send(command);

            //Produce_Consume_Events("Product has been updated");

            return Ok(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            return Ok(await mediator.Send(new DeleteProductCommand(id)));
        }

        /// <summary>
        /// Product and consume event while Add/Update Products
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
