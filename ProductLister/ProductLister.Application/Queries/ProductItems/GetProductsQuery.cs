using MediatR;
using ProductLister.Application.Dto;
using ProductLister.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Queries.ProductItems
{
    public record GetProductsQuery(string? NameFilter, Guid? CategoryFilter, int Page = 1, int PageSize = 10) : IRequest<PaginationWrapper<ProductItemDto>>;
}
