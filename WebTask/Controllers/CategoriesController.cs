using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebTask.Models;
using WebTask.Services;

namespace WebTask.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpPost]
        public IActionResult PostCategories([FromBody]Category category)
        {
            _categoryService.Add(category);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutCategories([FromBody]Category category, int id)
        {
            _categoryService.Update(category,id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleCategory(int id)
        {
            return Ok(_categoryService.Get(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSingleCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
