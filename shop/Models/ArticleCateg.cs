using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{

    public class ArticleCateg
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}