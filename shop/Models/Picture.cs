using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{

    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleId { get; set; }
        
        public virtual Article Article { get; set; }
        
    }
}