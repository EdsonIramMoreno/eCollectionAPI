using Core.DTO.Category;

namespace Core.Interfaces.Category
{
    public interface ICategoryServices
    {
        public Task<List<CategoryDTO>> getAllCategories();
        public Task<List<CategoryDTO>> getCategoryById(int categoryId);
    }
}
