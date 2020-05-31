using Shop_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop.Models;
using shop.Helpers;
using System;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopContext model;

        public CategoriesController(ShopContext _model){

            this.model = _model;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            return (await this.model.Categories.ToListAsync()).ToDTO();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetOne(int id)
        {
            var category = await model.Categories.FindAsync(id);
            if(category == null)
                return NotFound();

            return category.ToDTO();
        }
     
        [Authorized(Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CategoryDTO data){

            var category = await model.Categories.SingleOrDefaultAsync(c => c.Name == data.Name);
            if(category != null) {
                var error = new ValidationErrors().Add("This category already exists !", nameof(category.Name));
                return BadRequest(error);
            }
            var newCategory= new Category()
            {
                Name = data.Name,
                Timestamp = DateTime.Now
            };

            model.Categories.Add(newCategory);
            var res = await model.SaveChangesAsyncWithValidation();
            if(!res.IsEmpty)
                return BadRequest(res);

            return CreatedAtAction(nameof(GetOne), new {id = newCategory.Id}, newCategory.ToDTO());
        }

        [Authorized(Role.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryDTO data)
        {
            var category = await model.Categories.FindAsync(id);
            
            if(category == null)
                return NotFound();

            category.Name = data.Name;
            category.Timestamp = DateTime.Now;

            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }

        [Authorized(Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await model.Categories.FindAsync(id);

            if(category == null){
                return NotFound();
            }
            model.Categories.Remove(category);             
            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }
       
    }
}