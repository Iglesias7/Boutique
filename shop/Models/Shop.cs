using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public enum Type
    {
        Deuxieme = 2, Premiere = 1
    }
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string PicturePath { get; set; }
        public Type Type { get; set; } = Type.Deuxieme;
               
        public int AuthorId { get; set; } 
        public virtual User Author { get; set; }

        public virtual IList<ShopCateg> ShopCategs { get; set; } = new List<ShopCateg>();
        public virtual IList<Article> Articles { get; set; } = new List<Article>();
        public virtual IList<Vote> Votes { get; set; } = new List<Vote>();

        public virtual IEnumerable<Category> Categories { get => ShopCategs.Select(sc => sc.Category); }

    }
}