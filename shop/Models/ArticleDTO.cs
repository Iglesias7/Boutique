using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public int Price { get; set; }
        public int NumAvailableCopies { get; set; }
        // public int NumAvailableCopies { get { return this.Copies.Count; } set; }
               
        public int AuthorId { get; set; } 
        public int ShopId { get; set; } 
        public virtual UserDTO Author { get; set; }
        public virtual ShopDTO Shop { get; set; }

        public virtual IList<CategoryDTO> Categories { get; set; }
        public virtual IList<PictureDTO> Pictures { get; set; }
        public virtual IList<ArticleCopyDTO> Copies { get; set; }
    }
}