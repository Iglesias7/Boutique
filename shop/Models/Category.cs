using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public DateTime Timestamp { get; set; }

        // public virtual IList<Shop> Shops { get; set; } = new List<Shop>();
        // public virtual IList<Article> Articles { get; set; } = new List<Article>();

        public virtual IList<ShopCateg> ShopCategs { get; set; } = new List<ShopCateg>();
        public virtual IList<ArticleCateg> ArticleCategs { get; set; } = new List<ArticleCateg>();

        public virtual IEnumerable<Article> Articles { get => ArticleCategs.Select(ac => ac.Article); }
        public virtual IEnumerable<Shop> Shops { get => ShopCategs.Select(ac => ac.Shop); }
    }
}