using MediatR;
using ProductLister.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Queries.Categories
{
    public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;
}
