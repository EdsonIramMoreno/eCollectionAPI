using Core.DTO.Category;
using Core.DTO.Item.ItemInfo;
using Core.Interfaces.Category;
using Microsoft.AspNetCore.Mvc;

namespace API.Contorllers
{
    [Route("api/categories")] //https://localhost:7001/api/categories
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices services;

        public CategoryController(ICategoryServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public async Task<ActionResult<returnCategoryDTO>> getAllCategories()
        {
            returnCategoryDTO response = await services.getAllCategories();

            return StatusCode(response.status, response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<ActionResult<returnItemInfoDisplayDTO>> getCategoryById(int categoryId)
        {
            returnCategoryDTO response = await services.getCategoryById(categoryId);

            return StatusCode(response.status, response);
        }
    }
}
