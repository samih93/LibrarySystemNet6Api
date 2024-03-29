﻿using LibraryApi.services.category;
using LibraryModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository; 
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Getcategories()
        {
            

            return Ok(await _categoryRepository.GetCategories());
        }

        // POST: api/categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Category> AddCategory(Category category)
        {

            return await _categoryRepository.AddCategory(category);

        }

        // GET: api/categories/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                if (await _categoryRepository.GetCategories() == null)
                {
                    return NotFound();
                }

                var result = await _categoryRepository.GetCategory(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPut]
        // put: api/categories
        public async Task<Category> UpdateCategory(Category category)
        {

            return await _categoryRepository.UpdateCategory(category);

        }

        [HttpDelete]
        // put: api/categories
        public async Task DeleteCategory(int id)
        {

            await _categoryRepository.DeleteCategory(id);

        }
    }
}
