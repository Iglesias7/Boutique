using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int Price { get; set; }
        public int NumAvailableCopies { get; set; }
               
        public int AuthorId { get; set; } 
        public int ShopId { get; set; } 
        public virtual User Author { get; set; }
        public virtual Shop Shop { get; set; }

        public virtual IList<ArticleCateg> ArticleCategs { get; set; } = new List<ArticleCateg>();
        public virtual IList<Picture> Pictures { get; set; } = new List<Picture>();
        public virtual IList<ArticleCopy> Copies { get; set; } = new List<ArticleCopy>();

        public virtual IEnumerable<Category> Categories { get => ArticleCategs.Select(ac => ac.Category); }
    }
}