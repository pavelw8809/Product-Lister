using ProductLister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Domain.Interfaces.Categories
{
    public interface ICategoryCommandRepository
    {
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
