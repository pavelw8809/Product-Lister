using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLister.Infrastructure.Helpers
{
    public static class SqlReader
    {
        public static string GetSqlCommand(string type, string name)
        {
            try
            {
                var basePath = AppContext.BaseDirectory;
                return File.ReadAllText(Path.Combine(basePath, "Repositories", type, "Sql", name));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Cannot read sql command file: {type}/Sql/{name}", ex);
            }
        }
    }
}
