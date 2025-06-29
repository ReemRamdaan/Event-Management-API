using AutoMapper;
using Event_Management.DTOs.Category;
using Event_Management.DTOs.Organiser;
using Event_Management.Interfaces;
using Event_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        private readonly IMapper _map;
        public CategoryController(ICategory _category, IMapper _map) {
            this._category = _category;
            this._map = _map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            List<Category> categories = await _category.GetAllCategories();
            List<ReadCategoryDTO> categoriesDto = _map.Map<List<ReadCategoryDTO>>(categories);
            return Ok(categoriesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            Category category = await _category.GetCategory(id);
            if (category == null) {
                return NotFound("There is no Category with this ID");
            }
            ReadCategoryDTO categoryDto = _map.Map<ReadCategoryDTO>(category);
            return Ok(categoryDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO newCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var category = _map.Map<Category>(newCategoryDto);
            await _category.AddCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { category.Id }, newCategoryDto);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            bool result = await _category.DeleteCategory(id);
            if (result) return Ok(result);
            return NotFound("There is no Category with this ID");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO newCategoryDto, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Category newCategory = _map.Map<Category>(newCategoryDto);
            bool result = await _category.UpdateCategory(newCategory, id);
            if (result) return Ok(newCategoryDto);
            else return NotFound("There is no Category with this ID");

        }
    }
}
