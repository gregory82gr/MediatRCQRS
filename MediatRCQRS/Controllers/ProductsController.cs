using MediatR;
using MediatRCQRS.Commands;
using MediatRCQRS.Models;
using MediatRCQRS.Notifications;
using MediatRCQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MediatRCQRS.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            var  productToReturn = await _mediator.Send(new UpdateProductCommand(product));

            //TODO ProductUpdatedNotification
            await _mediator.Publish(new ProductUpdatedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));

            return StatusCode(200);
        }



    }
}
