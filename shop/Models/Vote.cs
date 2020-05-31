using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{

    public class Vote
    {
        public int UpDown { get; set; }
        public int AuthorId { get; set; }
        public int ShopId { get; set; }
        
        public virtual User Author {get; set; }
        public virtual Shop Shop { get; set; }
        
    }
}