using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using ProductLister.Domain.Entities;
using ProductLister.Domain.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Infrastructure.Repositories.Categories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly IDbConnection _dbCon;

        public CategoryQueryRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProductListerDb");
            _dbCon = new NpgsqlConnection(connectionString);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct)
        {
            string sql = Helpers.SqlReader.GetSqlCommand("categories", "GetAllCategories.sql");
            var cmd = new CommandDefinition(sql, cancellationToken: ct);
            return await _dbCon.QueryAsync<Category>(cmd);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> Ids, CancellationToken ct)
        {
            string sql = Helpers.SqlReader.GetSqlCommand("categories", "GetAllCategoriesByIds.sql");
            var parameters = new
            {
                CategoryIds = Ids.ToArray()
            };
            var cmd = new CommandDefinition(sql, parameters, cancellationToken: ct);
            return await _dbCon.QueryAsync<Category>(cmd);
        }
    }
}
