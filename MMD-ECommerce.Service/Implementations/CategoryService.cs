using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateCategory(Category category)
        {
            if (category == null) return "Bad Request";

            await _unitOfWork.Repository<Category, int>().AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<string> DeleteCategory(int id)
        {
            var category = await _unitOfWork.Repository<Category, int>().GetAsync(id);

            if (category == null) return "Not Found";

            _unitOfWork.Repository<Category, int>().Delete(category);

            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<string> EditCategory(Category category)
        {
            var existingCategory = await _unitOfWork.Repository<Category, int>().GetAsync(category.Id);

            if (existingCategory == null)
            {
                return "Category not found";
            }

            // Detach the existing tracked entity
            _unitOfWork.Repository<Category, int>().Detach(existingCategory);

            _unitOfWork.Repository<Category, int>().Update(category);
            await _unitOfWork.CompleteAsync();

            return "Success";
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
            => await _unitOfWork.Repository<Category, int>().GetAllAsync();

        public async Task<Category?> GetCategoryById(int id)
            => await _unitOfWork.Repository<Category, int>().GetAsync(id);

        public async Task<bool> IsCategoryExist(string name)
        {
            var categories = await _unitOfWork.Repository<Category, int>().GetAllAsync();

            foreach (var category in categories)
            {
                if (category.Name.Equals(name))
                    return false;
            }

            return true;
        }

        public async Task<bool> IsCategoryExistExcludeSelf(string name, int catId)
        {
            var allCategories = await _unitOfWork.Repository<Category, int>().GetAllAsync();
            return !allCategories.Any(c => c.Name == name && c.Id != catId);
        }

    }
}
