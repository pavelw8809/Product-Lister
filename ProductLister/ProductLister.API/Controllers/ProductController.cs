using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductLister.Application.Commands.ProductItems;
using ProductLister.Application.Dto;
using ProductLister.Application.Models;
using ProductLister.Application.Queries.ProductItems;

namespace ProductLister.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationWrapper<ProductItemDto>>> GetProducts(string? name, Guid? id, int page = 1, int pageSize = 10, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetProductsQuery(name, id, page, pageSize), ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductItemDto>> AddProduct([FromBody] NewProductItemDto NewProduct, CancellationToken ct)
        {
            var result = await _mediator.Send(new AddNewProductQuery(NewProduct), ct);
            return CreatedAtAction(nameof(AddProduct), result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductItemDto>> EditProduct([FromBody] EditProductDto productDto, CancellationToken ct)
        {
            var result = await _mediator.Send(new EditProductQuery(productDto), ct);
            return CreatedAtAction(nameof(EditProduct), result);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteProduct([FromBody] Guid ProductId, CancellationToken ct)
        {
            var result = await _mediator.Send(new DeleteProductQuery(ProductId), ct);
            return Ok(result);
        }
    }
}
