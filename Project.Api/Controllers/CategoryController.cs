using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Object;

namespace Project.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly ICategoryOperations _categoryOperations;

        public CategoryController(ICategoryOperations categoryOperations) {
            _categoryOperations = categoryOperations;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories() {
            var response = _categoryOperations.GetAll();
            return Ok(response);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) {
            var response = _categoryOperations.GetById(id);
            return Ok(response);
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category) {
            var response = _categoryOperations.Create(category);
            return Ok(response);
        }
    }
}
