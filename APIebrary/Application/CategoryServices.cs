using Core.DTO;
using Core.DTO.Category;
using Core.Interfaces.Category;
using Core.Mappers;

namespace API.Application
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<returnCategoryDTO> getAllCategories()
        {
            try
            {
                // 1 Get CategoryModList
                var categoriesMod = await categoryRepository.getAllCategories();

                List<CategoryDTO> categories = new List<CategoryDTO>();

                // 2 Map MOD to DTO
                foreach(var category in categoriesMod)
                {
                    categories.Add(CategoryMapper.mapMODtoDTO(category));
                }


                // 3 Return "returnCategoryDTO"
                if(categories.Count <= 0)
                    return new returnCategoryDTO
                    {
                        status = 404,
                        response = "CategoryList was NOT found.",
                        errors = null,
                        categories = null
                    };

                return new returnCategoryDTO
                {
                    status = 200,
                    response = "CategoryList was found.",
                    errors = null,
                    categories = categories
                };
            }
            catch (Exception ex)
            {
                return new returnCategoryDTO
                {
                    status = 500,
                    response = "One or more errors happend in the search.",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    categories = null
                };
            }
        }

        public async Task<returnCategoryDTO> getCategoryById(int categoryId)
        {
            try
            {
                // 1 Get CategoryModList
                var categoryMod = await categoryRepository.getCategoryById(categoryId);

                List<CategoryDTO> categories = new List<CategoryDTO>();

                // 2 Map MOD to DTO
                    categories.Add(CategoryMapper.mapMODtoDTO(categoryMod));
                


                // 3 Return "returnCategoryDTO"
                if (categories.Count <= 0)
                    return new returnCategoryDTO
                    {
                        status = 404,
                        response = "CategoryList was NOT found.",
                        errors = null,
                        categories = null
                    };

                return new returnCategoryDTO
                {
                    status = 200,
                    response = "CategoryList with ID: " + categoryId.ToString() + " was found.",
                    errors = null,
                    categories = categories
                };
            }
            catch (Exception ex)
            {
                return new returnCategoryDTO
                {
                    status = 500,
                    response = "One or more errors happend in the search.",
                    errors = new List<ErrorDTO> { new ErrorDTO { message = ex.Message, stackTrace = ex.StackTrace } },
                    categories = null
                };
            }
        }
    }
}
