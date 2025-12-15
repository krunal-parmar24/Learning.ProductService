using Learning.ProductService.Application.Commands;
using Learning.ProductService.Application.DTOs;
using Learning.ProductService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Learning.ProductService.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] List<int> productIds)
        {
            var query = new GetProductsQuery(productIds);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDto request)
        {
            var command = new AddProductCommand(request.Name, request.Description, request.Amount, request.Quantity);
            var newlyAddedProductId = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddProduct), new { id = newlyAddedProductId }, newlyAddedProductId);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto request)
        {
            var command = new UpdateProductCommand(id, request.Name, request.Description, request.Amount, request.Quantity);
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
