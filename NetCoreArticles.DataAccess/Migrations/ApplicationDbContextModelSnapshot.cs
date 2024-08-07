﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCoreArticles.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetCoreArticles.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.ArticleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(4980));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(5150));

                    b.Property<int>("Views")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.ImageEntity", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ArticleId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.LikeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 8, 6, 19, 51, 44, 661, DateTimeKind.Utc).AddTicks(7580));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.ArticleEntity", b =>
                {
                    b.HasOne("NetCoreArticles.DataAccess.Entities.UserEntity", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.ImageEntity", b =>
                {
                    b.HasOne("NetCoreArticles.DataAccess.Entities.ArticleEntity", "Article")
                        .WithOne("ArticleImage")
                        .HasForeignKey("NetCoreArticles.DataAccess.Entities.ImageEntity", "ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.LikeEntity", b =>
                {
                    b.HasOne("NetCoreArticles.DataAccess.Entities.ArticleEntity", "Article")
                        .WithMany("Likes")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCoreArticles.DataAccess.Entities.UserEntity", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.ArticleEntity", b =>
                {
                    b.Navigation("ArticleImage");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("NetCoreArticles.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}