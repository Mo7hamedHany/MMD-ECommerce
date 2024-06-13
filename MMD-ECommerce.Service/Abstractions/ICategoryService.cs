using MMD_ECommerce.Data.Models.Products;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<string> CreateCategory(Category category);
        Task<bool> IsCategoryExist(string name);
        Task<bool> IsCategoryExistExcludeSelf(string name, int catId);
        Task<string> EditCategory(Category category);
        Task<string> DeleteCategory(int id);
    }
}
