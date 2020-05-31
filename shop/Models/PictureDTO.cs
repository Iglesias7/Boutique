using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class PictureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

       public int ArticleId { get; set; }
        public virtual ArticleDTO Article { get; set; }
    }
}