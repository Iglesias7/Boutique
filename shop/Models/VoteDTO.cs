using System;
using System.Collections.Generic;

namespace shop.Models
{

    public class VoteDTO
    {
        public int UpDown { get; set; }

        public int ShopId { get; set; }
        public int AuthorId { get; set; }
    }
}