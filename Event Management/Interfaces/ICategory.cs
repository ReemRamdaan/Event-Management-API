using Event_Management.Models;

namespace Event_Management.Interfaces
{
    public interface ICategory
    {
        public Task<Category> GetCategory(int id);
        public Task<List<Category>> GetAllCategories();
        public Task<bool> AddCategory(Category category);
        public Task<bool> UpdateCategory(Category category, int id);
        public Task<bool> DeleteCategory(int id);
    }
}
