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

    public class ArticlesController : ControllerBase {

        private readonly ShopContext model;

        public ArticlesController(ShopContext _model){
            this.model = _model;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDTO>> GetOne(int id)
        {
            var articles =await model.Articles.FindAsync(id);
            if(articles == null)
                return NotFound();
            return articles.ToDTO();
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<ArticleDTO>> Post(int id, ArticleDTO data)
        {

            var user = await model.Users.FindAsync(data.AuthorId);
            if(user == null)
                return BadRequest();
            var shop = await model.Shops.FindAsync(data.ShopId);
            if(shop == null)
                return BadRequest();
            
            var newArticle = new Article()
            {
               Name = data.Name,
               Description = data.Description,
               Timestamp = DateTime.Now,
               AuthorId = data.AuthorId,
               Price = data.Price
            };

            model.Articles.Add(newArticle);

            var res = await model.SaveChangesAsyncWithValidation();
            if(!res.IsEmpty)
                return BadRequest(res);

            return CreatedAtAction(nameof(GetOne), new {id = newArticle.Id}, newArticle.ToDTO());
         }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PUT(int id, ArticleDTO data)
        {

            var article = await model.Articles.FindAsync(id);
            if(article == null)
                return NotFound();

            if(!(User.IsInRole(Role.Admin.ToString()) || article.Author.Pseudo == User.Identity.Name))
                return BadRequest();

            article.Name = data.Name;
            article.Description = data.Description;
            article.Timestamp = DateTime.Now;
            article.Price = data.Price;

            await model.SaveChangesAsyncWithValidation();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await model.Shops.FindAsync(id);

            if(!(User.IsInRole(Role.Admin.ToString()) || article.Author.Pseudo == User.Identity.Name))
                return BadRequest();

            model.Shops.Remove(article);

            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }

    }
}
