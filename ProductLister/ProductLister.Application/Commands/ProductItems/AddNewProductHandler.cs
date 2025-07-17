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
    public class AddNewProductHandler : IRequestHandler<AddNewProductQuery, ProductItemDto>
    {
        private readonly IProductCommandRepository _productRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public AddNewProductHandler(IProductCommandRepository productRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _productRepository = productRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<ProductItemDto> Handle(AddNewProductQuery request, CancellationToken ct)
        {
            var product = new Product
            {
                ProductName = request.NewProduct.Name,
                ProductVendor = request.NewProduct.Vendor,
                ProductPrice = decimal.Round(request.NewProduct.Price, 2, MidpointRounding.AwayFromZero),
                CategoryIds = request.NewProduct.CategoryIds
            };

            var newItem = await _productRepository.AddProductAsync(product, ct);
            var categories = await _categoryQueryRepository.GetCategoriesByIdsAsync(request.NewProduct.CategoryIds, ct);

            return new ProductItemDto
            {
                Id = newItem.ProductId,
                Name = newItem.ProductName,
                Vendor = newItem.ProductVendor,
                Price = decimal.Round(newItem.ProductPrice, 2, MidpointRounding.AwayFromZero),
                Categories = categories.Select(c => new CategoryDto
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName,
                    Color = c.CategoryColor
                }).ToList()
            };
        }
    }
}
