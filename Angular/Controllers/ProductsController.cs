using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Products;

namespace Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("list")]
        public IActionResult List()
        {
            var products = _productService.GetProductList();
            return Json(products);
        }
    }
}
