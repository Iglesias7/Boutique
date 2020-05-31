using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Models
{
    public static class DTOMappers {

//----------------------------UserDTO-------------------------------------------------------
        public static UserDTO ToDTO(this User user) {
            return new UserDTO {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Reputation = user.Reputation,
                PicturePath = user.PicturePath,
                Role = user.Role,
                Token = user.Token,
                RefreshToken = user.RefreshToken
            };
        }

        public static List<UserDTO> ToDTO(this IEnumerable<User> users) {
            return users.Select(u => u.ToDTO()).ToList();
        }

//---------------------------ShopDTO----------------------------------------------------------------
        public static ShopDTO ToDTO(this Shop shop) {
            return new ShopDTO {
                Id = shop.Id,
                Title = shop.Title,
                Description = shop.Description,
                Timestamp = shop.Timestamp,
                PicturePath = shop.PicturePath,
                Type = shop.Type,

                AuthorId = shop.AuthorId,
                Author = shop.Author.ToDTO(),
                
                Categories = shop.Categories.ToDTO(),
                Articles = shop.Articles.ToDTO(),
                Votes = shop.Votes.ToDTO()
            };
        }

        public static List<ShopDTO> ToDTO(this IEnumerable<Shop> shops) {
            return shops.Select(s => s.ToDTO()).ToList();
        }

//---------------------------ArticleDTO----------------------------------------------------------------
        public static ArticleDTO ToDTO(this Article article) {
            return new ArticleDTO {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Timestamp = article.Timestamp,
                Price = article.Price,
                NumAvailableCopies = article.NumAvailableCopies,

                AuthorId = article.AuthorId,
                ShopId = article.ShopId,
                
                Categories = article.Categories.ToDTO(),
                Pictures = article.Pictures.ToDTO(),
                Copies = article.Copies.ToDTO()
            };
        }

        public static List<ArticleDTO> ToDTO(this IEnumerable<Article> article) {
            return article.Select(a => a.ToDTO()).ToList();
        }
//------------------------categoryDTO--------------------------------------------------
        public static CategoryDTO ToDTO(this Category category) {
            return new CategoryDTO {
                Id = category.Id,
                Name = category.Name,
                Timestamp = category.Timestamp

                // Shops = category.Shops.ToDTO(),
                // Articles = category.Articles.ToDTO()
            };
        }

        public static List<CategoryDTO> ToDTO(this IEnumerable<Category> category) {
            return category.Select(c => c.ToDTO()).ToList();
        }
//----------------------------VoteDTO-----------------------------------------------------
        public static VoteDTO ToDTO(this Vote vote) {
            return new VoteDTO {
                UpDown = vote.UpDown,

                AuthorId = vote.AuthorId,
                ShopId = vote.ShopId,
            };
        }

        public static List<VoteDTO> ToDTO(this IEnumerable<Vote> votes) {
            return votes.Select(v => v.ToDTO()).ToList();
        }

//-----------------------ArticleCopyDTO--------------------------------------------------------
         public static ArticleCopyDTO ToDTO(this ArticleCopy articleCopy) {
             return new ArticleCopyDTO {
                 Id = articleCopy.Id,
                 Timestamp = articleCopy.Timestamp,

                 ArticleId = articleCopy.ArticleId,
                 Article = articleCopy.Article.ToDTO()
             };
         }

         public static List<ArticleCopyDTO> ToDTO(this IEnumerable<ArticleCopy> articleCopy) {
             return articleCopy.Select(ac => ac.ToDTO()).ToList();
         }
//-----------------------ArticleCopyDTO--------------------------------------------------------
         public static PictureDTO ToDTO(this Picture picture) {
            return new PictureDTO {
                Id = picture.Id,
                Name = picture.Name,

                ArticleId = picture.ArticleId,
                Article = picture.Article.ToDTO()
            };
        }

         public static List<PictureDTO> ToDTO(this IEnumerable<Picture> pictures) {
             return pictures.Select(p => p.ToDTO()).ToList();
         }
    }
}