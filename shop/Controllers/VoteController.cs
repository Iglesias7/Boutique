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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class VotesController : ControllerBase {

        private readonly ShopContext model;

        public VotesController(ShopContext _model){
            this.model = _model;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(VoteDTO data)
        {
            var shop = await model.Shops.FindAsync(data.ShopId);
            if(shop == null)
                return NotFound();

            var vote = await model.Votes.SingleOrDefaultAsync(p => p.AuthorId == data.AuthorId && p.ShopId == data.ShopId);
            
            var user = await model.Users.SingleOrDefaultAsync(u => u.Pseudo == User.Identity.Name);
            if(user == null)
                return NotFound();
            else if(data.UpDown == 1 && user.Reputation < 15)
                return NotFound("Vous devez avoir au moins une réputation de 15 pour voter positivement.");
            else if(data.UpDown == -1 && user.Reputation < 30)
                return NotFound("Vous devez avoir au moins une réputation de 30 pour voter négativement.");

            Vote newVote = new Vote()
            {
                UpDown = data.UpDown,
                AuthorId = data.AuthorId,
                ShopId = data.ShopId
            };
            
            if(vote != null){
                model.Votes.Remove(vote);
                if(vote.UpDown == 1){
                    shop.Author.Reputation -= 10; 
                }else {
                    shop.Author.Reputation += 2; 
                    user.Reputation += 1;
                }
            }

            model.Votes.Add(newVote);
            if(data.UpDown == 1){
                shop.Author.Reputation += 10; 
            } else {
                shop.Author.Reputation -= 2; 
            }
            
            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await model.Users.SingleOrDefaultAsync(u => u.Pseudo == User.Identity.Name);
            var shop = await model.Shops.FindAsync(id);
            if(shop == null)
                return NotFound();
            var vote = await model.Votes.SingleOrDefaultAsync(p => p.AuthorId == user.Id && p.ShopId == id);

            if(vote != null) {
                model.Votes.Remove(vote);
                if(vote.UpDown == 1){
                    shop.Author.Reputation -= 10; 
                } else {
                    shop.Author.Reputation += 2; 
                    user.Reputation += 1;
                }
            } else {
                return BadRequest();
            }

            await model.SaveChangesAsyncWithValidation();

            return NoContent();
        }
    }
}
