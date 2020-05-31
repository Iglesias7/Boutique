using System;
using Shop_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Security.Claims;
using shop.Helpers;

namespace shop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ShopController : ControllerBase {

        private readonly ShopContext model;

        public ShopController(ShopContext _model){
            this.model = _model;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDTO>> GetOne(int id)
        {
            var shop =await model.Shops.FindAsync(id);
            if(shop == null)
                return NotFound();
            return shop.ToDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ShopDTO>> PostShop(ShopDTO data)
        {
            var user = await model.Users.FindAsync(data.AuthorId);
            if(user == null)
                return BadRequest();
            
            var newShop = new Shop()
            {
               Title = data.Title,
               Description = data.Description,
               Timestamp = DateTime.Now,
               AuthorId = data.AuthorId,
               PicturePath = data.PicturePath,
               Type = data.Type
            };

            model.Shops.Add(newShop);

            var res = await model.SaveChangesAsyncWithValidation();
            if(!res.IsEmpty)
                return BadRequest(res);

            return CreatedAtAction(nameof(GetOne), new {id = newShop.Id}, newShop.ToDTO());
         }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PUT(int id, ShopDTO data)
        {

            var shop = await model.Shops.FindAsync(id);
            if(shop == null)
                return NotFound();

            if(!(User.IsInRole(Role.Admin.ToString()) || shop.Author.Pseudo == User.Identity.Name))
                return BadRequest();

            shop.Title = data.Title;
            shop.Description = data.Description;
            shop.Timestamp = DateTime.Now;
            shop.Type = data.Type;

            if (!string.IsNullOrWhiteSpace(data.PicturePath))
                shop.PicturePath = data.PicturePath + "?" + DateTime.Now.Ticks;
            else
                shop.PicturePath = null;

            await model.SaveChangesAsyncWithValidation();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await model.Shops.FindAsync(id);

            if(!(User.IsInRole(Role.Admin.ToString()) || shop.Author.Pseudo == User.Identity.Name))
                return BadRequest();

            model.Shops.Remove(shop);

            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }

    }
}
