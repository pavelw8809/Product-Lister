using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProductLister.Application.Models;
using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Infrastructure.Repositories.Products
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private record ProductCategoryRow(
            Guid ProductId,
            string ProductName,
            string ProductVendor,
            decimal ProductPrice,
            Guid CategoryId
        );

        private readonly IDbConnection _dbCon;

        public ProductQueryRepository(IConfiguration configuration)
        {
            var connectingString = configuration.GetConnectionString("ProductListerDb");
            _dbCon = new NpgsqlConnection(connectingString);
        }

        public async Task<(IEnumerable<Product> items, int totalCount, int totalPages)> GetFilteredProductsAsync(string name, Guid? categoryId, int page, int pageSize, CancellationToken ct)
        {
            string sql;
            string countSql;
            object parameters;
            object countParameters;

            if (name is not null)
            {
                sql = Helpers.SqlReader.GetSqlCommand("products", "GetAllProductsByName.sql");
                parameters = new
                {
                    ProductName = $"%{name}%",
                    PageSize = pageSize,
                    Page = page
                };
                countSql = Helpers.SqlReader.GetSqlCommand("products", "CountAllProductsByName.sql");
                countParameters = new
                {
                    ProductName = $"%{name}%"
                };
            }
            else if (categoryId is not null)
            {
                sql = Helpers.SqlReader.GetSqlCommand("products", "GetAllProductsByCategoryId.sql");
                parameters = new
                {
                    CategoryId = categoryId,
                    PageSize = pageSize,
                    Page = page
                };
                countSql = Helpers.SqlReader.GetSqlCommand("products", "CountAllProductsByCategoryId.sql");
                countParameters = new
                {
                    CategoryId = categoryId,
                };
            }
            else
            {
                sql = Helpers.SqlReader.GetSqlCommand("products", "GetAllProducts.sql");
                parameters = new
                {
                    PageSize = pageSize,
                    Page = page
                };
                countSql = Helpers.SqlReader.GetSqlCommand("products", "CountAllProducts.sql");
                countParameters = new { };
            }

            var countCmd = new CommandDefinition(countSql, countParameters, cancellationToken: ct);
            var totalItems = await _dbCon.ExecuteScalarAsync<int>(countCmd);
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var cmd = new CommandDefinition(sql, parameters, cancellationToken: ct);
            IEnumerable<ProductCategoryRow> productCategoryItems = await _dbCon.QueryAsync<ProductCategoryRow>(sql, parameters);

            var products = productCategoryItems.GroupBy(pc => pc.ProductId).Select(g => new Product
            {
                ProductId = g.Key,
                ProductName = g.First().ProductName,
                ProductVendor = g.First().ProductVendor,
                ProductPrice = g.First().ProductPrice,
                CategoryIds = g.Select(c => c.CategoryId).Distinct().ToList()
            });

            return (products, totalItems, totalPages);
        }
    }
}
