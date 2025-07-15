using ProductLister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Domain.Interfaces.Products
{
    public interface IProductCommandRepository
    {
        Task<Product> AddProductAsync(Product product, CancellationToken ct);
        Task<Product> EditProductAsync(Product product, CancellationToken ct);
        Task<Guid?> DeleteProductAsync(Guid productId, CancellationToken ct);
    }
}
