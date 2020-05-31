using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class ShopDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string PicturePath { get; set; }
        public Type Type { get; set; }
               
        public int AuthorId { get; set; } 
        public UserDTO Author { get; set; }

        public virtual IList<CategoryDTO> Categories { get; set; }
        public virtual IList<ArticleDTO> Articles { get; set; }
        public virtual IList<VoteDTO> Votes { get; set; }
    }
}