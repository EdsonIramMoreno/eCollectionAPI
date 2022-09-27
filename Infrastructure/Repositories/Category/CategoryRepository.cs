using Core.DTO.User;
using Core.Entities.CategoryList;
using Core.Interfaces.Category;
using Dapper;
using Firebase.Auth;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext context;
        public CategoryRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoryMod>> getAllCategories()
        {
            var query = "sp_Category_get";

            using var connection = context.SQLConnection();
            List<CategoryMod> category = (await connection.QueryAsync<CategoryMod>(query,null, commandType: CommandType.StoredProcedure)).ToList();
            
            return category;
        }

        public async Task<CategoryMod> getCategoryById(int categoryId)
        {
            var query = "sp_Category_get";

            using var connection = context.SQLConnection();
            CategoryMod category = await connection.QueryFirstOrDefaultAsync<CategoryMod>(query, new { categoryId },commandType:CommandType.StoredProcedure);

            return category;
        }
    }
}
