using Core.DTO.Category;
using Core.Entities.CategoryList;

namespace Core.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDTO mapMODtoDTO(CategoryMod category)
        {
            return new CategoryDTO
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName
            };
        }

        public static CategoryMod mapDTOtoMOD(CategoryDTO category)
        {
            return new CategoryMod
            {
                categoryId = category.categoryId,
                categoryName = category.categoryName
            };
        }
    }
}
