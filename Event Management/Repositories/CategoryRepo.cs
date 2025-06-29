using Event_Management.Data;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.EntityFrameworkCore;
namespace Event_Management.Repositories
{
    public class CategoryRepo:ICategory
    {
        private readonly EventContext _context;
        public  CategoryRepo(EventContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await GetCategory(id);
            if (category == null)
            {
                return false;
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }



        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> UpdateCategory(Category updatedCategory, int id)
        {
            var existingCategory = await GetCategory(id);
            if (existingCategory == null)
            {
                return false;
            }
            existingCategory.Name = updatedCategory.Name;
            existingCategory.Description = updatedCategory.Description;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
