using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Commands.ProductItems
{
    public record DeleteProductQuery(Guid ProductId) : IRequest<Guid>;
}
