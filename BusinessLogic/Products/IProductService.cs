using System.Collections.Generic;
using SharedLibrary.Entity;

namespace BusinessLogic.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductList();
    }
}
