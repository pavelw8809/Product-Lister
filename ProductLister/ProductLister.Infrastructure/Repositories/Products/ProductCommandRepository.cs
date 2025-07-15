using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Infrastructure.Repositories.Products
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly NpgsqlConnection _dbCon;

        public ProductCommandRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProductListerDb");
            _dbCon = new NpgsqlConnection(connectionString);
        }

        public async Task<Product> AddProductAsync(Product product, CancellationToken ct)
        {
            await _dbCon.OpenAsync(ct);
            await using var transaction = await _dbCon.BeginTransactionAsync(ct);

            try
            {
                string sql = Helpers.SqlReader.GetSqlCommand("products", "AddNewProduct.sql");
                object parameters = new
                {
                    product.ProductId,
                    product.ProductName,
                    product.ProductVendor,
                    product.ProductPrice
                };

                var productId = await _dbCon.ExecuteScalarAsync<Guid>(sql, parameters, transaction);

                product.ProductId = productId;
                
                if (product.CategoryIds?.Count > 0)
                {
                    string pcSql = Helpers.SqlReader.GetSqlCommand("products", "AddNewProductCategory.sql");

                    var pcParameters = product.CategoryIds.Select(cid => new
                    {
                        ProductId = productId,
                        CategoryId = cid
                    });

                    await _dbCon.ExecuteAsync(pcSql, pcParameters, transaction);
                }

                await transaction.CommitAsync(ct);

                return product;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }

        public async Task<Product?> EditProductAsync(Product product, CancellationToken ct)
        {
            string sql = Helpers.SqlReader.GetSqlCommand("products", "EditProduct.sql");

            object parameters = new
            {
                product.ProductId,
                product.ProductName,
                product.ProductVendor,
                product.ProductPrice
            };

            var cmd = new CommandDefinition(sql, parameters, cancellationToken: ct);

            await _dbCon.ExecuteAsync(cmd);

            return product;
        }

        public async Task<Guid?> DeleteProductAsync(Guid productId, CancellationToken ct)
        {
            await _dbCon.OpenAsync(ct);
            await using var transaction = await _dbCon.BeginTransactionAsync(ct);

            try
            {
                object parameters = new
                {
                    productId
                };

                string pcSql = Helpers.SqlReader.GetSqlCommand("products", "DeleteProductFromProductCategory.sql");
                await _dbCon.ExecuteAsync(pcSql, parameters, transaction);

                string sql = Helpers.SqlReader.GetSqlCommand("products", "DeleteProduct.sql");
                int deletedRows = await _dbCon.ExecuteAsync(sql, parameters, transaction);

                if (deletedRows == 0)
                {
                    await transaction.RollbackAsync(ct);
                    return null;
                }

                await transaction.CommitAsync(ct);
                return productId;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw;
            }
        }
    }
}
