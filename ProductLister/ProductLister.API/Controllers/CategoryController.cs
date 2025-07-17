using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductLister.Application.Dto;
using ProductLister.Application.Queries.Categories;

namespace ProductLister.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery(), ct);
            return Ok(result);
        }
    }
}
