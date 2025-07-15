using MediatR;
using ProductLister.Application.Dto;
using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Queries.Categories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryQueryRepository _queryRepository;

        public GetAllCategoriesHandler(ICategoryQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery query, CancellationToken ct)
        {
            var categories = await _queryRepository.GetAllCategoriesAsync(ct);
            return categories.Select(c => new CategoryDto
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
                Color = c.CategoryColor
            });
        }
    }
}
