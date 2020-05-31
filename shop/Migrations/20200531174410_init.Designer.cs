﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop.Models;

namespace shop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20200531174410_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("shop.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("NumAvailableCopies");

                    b.Property<int>("Price");

                    b.Property<int>("ShopId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ShopId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("shop.Models.ArticleCateg", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategs");
                });

            modelBuilder.Entity("shop.Models.ArticleCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleCopies");
                });

            modelBuilder.Entity("shop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("shop.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("shop.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<string>("PicturePath");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("shop.Models.ShopCateg", b =>
                {
                    b.Property<int>("ShopId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ShopId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ShopCategs");
                });

            modelBuilder.Entity("shop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("PicturePath");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("RefreshToken");

                    b.Property<int>("Reputation");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Pseudo")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("shop.Models.Vote", b =>
                {
                    b.Property<int>("ShopId");

                    b.Property<int>("AuthorId");

                    b.Property<int>("UpDown");

                    b.HasKey("ShopId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("shop.Models.Article", b =>
                {
                    b.HasOne("shop.Models.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("shop.Models.Shop", "Shop")
                        .WithMany("Articles")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.ArticleCateg", b =>
                {
                    b.HasOne("shop.Models.Article", "Article")
                        .WithMany("ArticleCategs")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("shop.Models.Category", "Category")
                        .WithMany("ArticleCategs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.ArticleCopy", b =>
                {
                    b.HasOne("shop.Models.Article", "Article")
                        .WithMany("Copies")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.Picture", b =>
                {
                    b.HasOne("shop.Models.Article", "Article")
                        .WithMany("Pictures")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.Shop", b =>
                {
                    b.HasOne("shop.Models.User", "Author")
                        .WithMany("Shops")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.ShopCateg", b =>
                {
                    b.HasOne("shop.Models.Category", "Category")
                        .WithMany("ShopCategs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("shop.Models.Shop", "Shop")
                        .WithMany("ShopCategs")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("shop.Models.Vote", b =>
                {
                    b.HasOne("shop.Models.User", "Author")
                        .WithMany("Votes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("shop.Models.Shop", "Shop")
                        .WithMany("Votes")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
