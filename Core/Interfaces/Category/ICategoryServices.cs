using Core.DTO.Category;

namespace Core.Interfaces.Category
{
    public interface ICategoryServices
    {
        public Task<returnCategoryDTO> getAllCategories();
        public Task<returnCategoryDTO> getCategoryById(int categoryId);
    }
}
