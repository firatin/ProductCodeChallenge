using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Object;
using Project.Entities.ViewModel;

namespace Project.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IProductOperations _productOperations;

        public ProductController(IProductOperations productOperations) {
            _productOperations = productOperations;
        }

        [HttpGet("Products")]
        public IActionResult GetProducts() {
            var response = _productOperations.GetAll();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetProduct(int id) {
            var response = _productOperations.GetById(id);
            return Ok(response);
        }

        [HttpPost("Products")]
        public IActionResult GetProductList(ProductSearchModel searchModel) {
            var response = _productOperations.GetProductListByFilters(searchModel);
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product) {
            var response = _productOperations.Create(product);
            return Ok(response);
        }
    }
}
