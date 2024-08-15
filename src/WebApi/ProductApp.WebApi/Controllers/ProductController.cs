using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands.CreateProducts;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Interfaces;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var query = new GetAllProductQuery();
            return Ok(await _mediator.Send(query));
        } 
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            return Ok(await _mediator.Send(createProductCommand));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(){Id=id};
            return Ok(await _mediator.Send(query));
        }
    }
}
