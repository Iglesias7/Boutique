using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class ArticleCopyDTO
    {
       public int Id { get; set; }
        public DateTime Timestamp { get; set; }
               
        public int ArticleId { get; set; } 
        public virtual ArticleDTO Article { get; set; }

    }
}