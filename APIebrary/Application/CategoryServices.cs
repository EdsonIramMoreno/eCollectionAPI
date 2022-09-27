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

        public async Task<List<CategoryDTO>> getAllCategories()
        {
            try
            {
                // 1 Get CategoryModList
                var categoriesMod = await categoryRepository.getAllCategories();

                List<CategoryDTO> categories = new List<CategoryDTO>();

                // 2 Map MOD to DTO
                foreach (var category in categoriesMod)
                {
                    categories.Add(CategoryMapper.mapMODtoDTO(category));
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }

        public async Task<CategoryDTO> getCategoryById(int categoryId)
        {
            try
            {
                // 1 Get CategoryModList
                var categoryMod = await categoryRepository.getCategoryById(categoryId);

                var categories = new CategoryDTO();

                // 2 Map MOD to DTO
                    categories = CategoryMapper.mapMODtoDTO(categoryMod);
                
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
