
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

//---------------------------------------------------------------------------------------------------------------
            modelBuilder.Entity<User>().HasIndex(u => u.Pseudo).IsUnique(true);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(true);

            modelBuilder.Entity<Shop>().HasIndex(s => s.Title).IsUnique(true);

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique(true);

            modelBuilder.Entity<Picture>().HasIndex(p => p.Name).IsUnique(true);

//------------------------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Vote>().HasKey(v => new {v.ShopId, v.AuthorId});
            modelBuilder.Entity<ArticleCateg>().HasKey(v => new {v.ArticleId, v.CategoryId});
            modelBuilder.Entity<ShopCateg>().HasKey(v => new {v.ShopId, v.CategoryId});

//----------------------------------------------------------------------------------------------------------------

                
                // Shop.User (1) <--> User.Shop (*)
                modelBuilder.Entity<Shop>()
                    .HasOne<User>(s => s.Author)                  // définit la propriété de navigation pour le côté (1) de la relation
                    .WithMany(u => u.Shops)            // définit la propriété de navigation pour le côté (N) de la relation
                    .HasForeignKey(s => s.AuthorId)         // spécifie que la clé étrangère est Shop.PostId
                    .OnDelete(DeleteBehavior.Restrict);   // spécifie le comportement en cas de delete : ici, un refus

                
                 // ShopCateg.Shop (1) <--> Shop.ShopCategs (*)
                modelBuilder.Entity<ShopCateg>()
                    .HasOne<Shop>(sc => sc.Shop)
                    .WithMany(s => s.ShopCategs)
                    .HasForeignKey(sc => sc.ShopId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                // ShopCateg.Category (1) <--> Category.ShopCategs (*)
                modelBuilder.Entity<ShopCateg>()
                    .HasOne<Category>(sc => sc.Category)
                    .WithMany(c => c.ShopCategs)
                    .HasForeignKey(sc => sc.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                 // ArticleCateg.Article (1) <--> Article.ArticleCategs (*)
                modelBuilder.Entity<ArticleCateg>()
                    .HasOne<Article>(sc => sc.Article)
                    .WithMany(a => a.ArticleCategs)
                    .HasForeignKey(sc => sc.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                // ArticleCateg.Category (1) <--> Category.ArticleCategs (*)
                modelBuilder.Entity<ArticleCateg>()
                    .HasOne<Category>(sc => sc.Category)
                    .WithMany(c => c.ArticleCategs)
                    .HasForeignKey(sc => sc.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Article.User (1) <--> User.Articles (*)
                modelBuilder.Entity<Article>()
                    .HasOne<User>(a => a.Author)                  
                    .WithMany(u => u.Articles)            
                    .HasForeignKey(a => a.AuthorId)        
                    .OnDelete(DeleteBehavior.Restrict);

                // Article.Shop (1) <--> Shop.Articles (*)
                modelBuilder.Entity<Article>()
                    .HasOne<Shop>(a => a.Shop)                  
                    .WithMany(s => s.Articles)            
                    .HasForeignKey(a => a.ShopId)        
                    .OnDelete(DeleteBehavior.Restrict);

                // ArticleCopy.Article (1) <--> Article.ArticleCopies (*)
                modelBuilder.Entity<ArticleCopy>()
                    .HasOne<Article>(ac => ac.Article)
                    .WithMany(a => a.Copies)
                    .HasForeignKey(ac => ac.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Picture.Article (1) <--> Article.Pictures (*)
                modelBuilder.Entity<Picture>()
                    .HasOne<Article>(p => p.Article)
                    .WithMany(a => a.Pictures)
                    .HasForeignKey(f => f.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                // Vote.User (1) <--> User.Votes (*)
                modelBuilder.Entity<Vote>()
                    .HasOne<User>(v => v.Author)                  
                    .WithMany(u => u.Votes)            
                    .HasForeignKey(v => v.AuthorId)        
                    .OnDelete(DeleteBehavior.Restrict);

                // Vote.Shop (1) <--> Shop.Votes (*)
                modelBuilder.Entity<Vote>()
                    .HasOne<Shop>(v => v.Shop)                  
                    .WithMany(s => s.Votes)            
                    .HasForeignKey(v => v.ShopId)        
                    .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Article> Articles { get; set; }  
        public DbSet<Picture> Pictures { get; set; }        
        public DbSet<ArticleCopy> ArticleCopies { get; set; }        
        public DbSet<ArticleCateg> ArticleCategs { get; set; }        
        public DbSet<ShopCateg> ShopCategs { get; set; }        
    }
}