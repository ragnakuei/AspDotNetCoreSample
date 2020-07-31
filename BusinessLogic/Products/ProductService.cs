using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BusinessLogic.Configuration;
using Dapper;
using SharedLibrary.Entity;

namespace BusinessLogic.Products
{
    public class ProductService : IProductService
    {
        private readonly IConfigurationService _configurationService;

        public ProductService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public IEnumerable<Product> GetProductList()
        {
            var products   = Enumerable.Empty<Product>();

            try
            {
                using (var connection = new SqlConnection(_configurationService.ConnectionString("Northwind")))
                {
                    var sql = @"
select *
from dbo.[Products]
";
                    products = connection.Query<Product>(sql).ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return products;
        }
    }
}
