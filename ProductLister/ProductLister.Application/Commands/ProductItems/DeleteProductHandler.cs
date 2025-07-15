using MediatR;
using ProductLister.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Commands.ProductItems
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductQuery, Guid>
    {
        private readonly IProductCommandRepository _productRepository;

        public DeleteProductHandler(IProductCommandRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(DeleteProductQuery request, CancellationToken ct)
        {
            var result = await _productRepository.DeleteProductAsync(request.ProductId, ct);

            return result == null ? throw new KeyNotFoundException($"Product with ID {request.ProductId} was not found.") : result.Value;
        }
    }
}
