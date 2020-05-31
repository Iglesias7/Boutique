using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        // public virtual IList<ShopDTO> Shops { get; set; }
        // public virtual IList<ArticleDTO> Articles { get; set; }
    }
}