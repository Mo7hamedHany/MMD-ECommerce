using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories() 
            => await _unitOfWork.Repository<Category,int>().GetAllAsync();
    }
}
