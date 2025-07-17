using MediatR;
using ProductLister.Application.Dto;
using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Categories;
using ProductLister.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Application.Commands.ProductItems
{
    public class EditProductHandler : IRequestHandler<EditProductQuery, ProductItemDto>
    {
        private readonly IProductCommandRepository _productRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public EditProductHandler(IProductCommandRepository productRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _productRepository = productRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<ProductItemDto> Handle(EditProductQuery request, CancellationToken ct)
        {
            var product = new Product
            {
                ProductId = request.Product.Id,
                ProductName = request.Product.Name,
                ProductVendor = request.Product.Vendor,
                ProductPrice = decimal.Round(request.Product.Price, 2, MidpointRounding.AwayFromZero),
                CategoryIds = request.Product.CategoryIds
            };

            var modifiedItem = await _productRepository.EditProductAsync(product, ct);
            var categories = await _categoryQueryRepository.GetCategoriesByIdsAsync(request.Product.CategoryIds, ct);

            return new ProductItemDto
            {
                Id = modifiedItem.ProductId,
                Name = modifiedItem.ProductName,
                Vendor = modifiedItem.ProductVendor,
                Price = decimal.Round(modifiedItem.ProductPrice, 2, MidpointRounding.AwayFromZero),
                Categories = categories.Select(c => new CategoryDto
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    Color = c.CategoryColor
                }).ToList(),
            };
        }
    }
}
