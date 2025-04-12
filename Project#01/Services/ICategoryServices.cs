using Project_01.Models;

namespace Project_01.Services
{
    public interface ICategoryServices
    {
        public Task<Category> GetCategory(int id);
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> AddCategory(CategoryDto request);
        public Task<Category> UpdateCategory(int id, CategoryDto request);
        public Task<Category> DeleteCategory(int id);
    }
}
