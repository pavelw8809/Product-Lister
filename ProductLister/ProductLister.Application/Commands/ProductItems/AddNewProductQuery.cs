using MediatR;
using ProductLister.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Commands.ProductItems
{
    public record AddNewProductQuery(NewProductItemDto NewProduct) : IRequest<ProductItemDto>;
}
