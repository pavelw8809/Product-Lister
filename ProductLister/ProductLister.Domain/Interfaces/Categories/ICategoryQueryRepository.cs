using ProductLister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Domain.Interfaces.Categories
{
    public interface ICategoryQueryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct);
        Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> Ids, CancellationToken ct);
    }
}
