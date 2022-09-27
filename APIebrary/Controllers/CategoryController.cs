using Core.DTO;
using Core.Interfaces.Category;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> getAllCategories()
        {
            var response = await services.getAllCategories();

            if(response == null || response.Count < 1)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<ActionResult> getCategoryById(int categoryId)
        {
            var response = await services.getCategoryById(categoryId);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }
    }
}
