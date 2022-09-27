using Core.DTO.Category;

namespace Core.Interfaces.Category
{
    public interface ICategoryServices
    {
        public Task<List<CategoryDTO>> getAllCategories();
        public Task<CategoryDTO> getCategoryById(int categoryId);
    }
}
