using ProductLister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Domain.Interfaces.Products
{
    public interface IProductQueryRepository
    {
        Task<(IEnumerable<Product> items, int totalCount, int totalPages)> GetFilteredProductsAsync(string name, Guid? categoryId, int page, int pageSize, CancellationToken ct);
    }
}
