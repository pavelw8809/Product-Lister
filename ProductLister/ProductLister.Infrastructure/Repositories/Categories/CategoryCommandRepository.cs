using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Infrastructure.Repositories.Categories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        public Task AddCategoryAsync(Category category)
        {
            return null;
        }

        public Task DeleteCategoryAsync(int category)
        {
            return null;
        }
    }
}
