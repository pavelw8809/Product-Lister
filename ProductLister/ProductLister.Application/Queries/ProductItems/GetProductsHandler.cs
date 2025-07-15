using MediatR;
using ProductLister.Application.Dto;
using ProductLister.Application.Models;
using ProductLister.Domain.Interfaces.Categories;
using ProductLister.Domain.Interfaces.Products;

namespace ProductLister.Application.Queries.ProductItems
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PaginationWrapper<ProductItemDto>>
    {
        private readonly IProductQueryRepository _productRepository;
        private readonly ICategoryQueryRepository _categoryRepository;

        public GetProductsHandler(IProductQueryRepository productRepository, ICategoryQueryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<PaginationWrapper<ProductItemDto>> Handle(GetProductsQuery query, CancellationToken ct)
        {
            var products = await _productRepository.GetFilteredProductsAsync(query.NameFilter, query.CategoryFilter, query.Page, query.PageSize, ct);
            var usedCategories = products.items.SelectMany(p => p.CategoryIds).Distinct();
            var categories = await _categoryRepository.GetCategoriesByIdsAsync(usedCategories, ct);

            var categoriesDict = categories.ToDictionary(c => c.CategoryId);

            return new PaginationWrapper<ProductItemDto>
            {
                Page = query.Page,
                PageSize = query.PageSize,
                TotalCount = products.totalCount,
                TotalPages = products.totalPages,
                Items = products.items.Select(p => new ProductItemDto
                {
                    Id = p.ProductId,
                    Name = p.ProductName,
                    Vendor = p.ProductVendor,
                    Price = p.ProductPrice,
                    Categories = p.CategoryIds.Where(cid => categoriesDict.ContainsKey(cid)).Select(c => new CategoryDto
                    {
                        Id = categoriesDict[c].CategoryId,
                        Name = categoriesDict[c].CategoryName,
                        Color = categoriesDict[c].CategoryColor
                    }).ToList()
                }).ToList()
            };
        }
    }
}
