using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await this._categoryService.GetAllAsync();
            return Ok(categories);
        }

    }
}
