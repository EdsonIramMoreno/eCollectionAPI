using Core.DTO.Category;
using Core.Entities.CategoryList;

namespace Core.Interfaces.Category
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryMod>> getAllCategories();
        public Task<CategoryMod> getCategoryById(int categoryId);
    }
}
