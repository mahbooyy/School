﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using School.DAL;

namespace School.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("School.Domain.ModelsDb.CategoryDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Otziv")
                        .HasColumnType("text")
                        .HasColumnName("otziv");

                    b.Property<int>("PathImage")
                        .HasColumnType("integer")
                        .HasColumnName("pathImg");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.OrdersDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("Id_Product")
                        .HasColumnType("uuid")
                        .HasColumnName("id_product");

                    b.Property<Guid>("Id_User")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid?>("UserDbId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserDbId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.PictureProductDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("Id_Product")
                        .HasColumnType("uuid")
                        .HasColumnName("id_product");

                    b.Property<string>("PathImage")
                        .HasColumnType("text")
                        .HasColumnName("pathImage");

                    b.HasKey("Id");

                    b.ToTable("picture_product");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.ProductsDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoryDbId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<Guid>("Id_Category")
                        .HasColumnType("uuid")
                        .HasColumnName("id_category");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("OderDbId")
                        .HasColumnType("uuid");

                    b.Property<int>("PathImage")
                        .HasColumnType("integer")
                        .HasColumnName("pathImg");

                    b.Property<Guid?>("PictureProducId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Product")
                        .HasColumnType("numeric")
                        .HasColumnName("product");

                    b.HasKey("Id");

                    b.HasIndex("CategoryDbId");

                    b.HasIndex("OderDbId");

                    b.HasIndex("PictureProducId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.RequestDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("Id_User")
                        .HasColumnType("uuid")
                        .HasColumnName("id_user");

                    b.Property<string>("PathImage")
                        .HasColumnType("text")
                        .HasColumnName("pathImage");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<Guid?>("UserDbId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserDbId");

                    b.ToTable("request");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.UserDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PathImage")
                        .HasColumnType("text")
                        .HasColumnName("pathImage");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.OrdersDb", b =>
                {
                    b.HasOne("School.Domain.ModelsDb.UserDb", "UserDb")
                        .WithMany("ordersDb")
                        .HasForeignKey("UserDbId");

                    b.Navigation("UserDb");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.ProductsDb", b =>
                {
                    b.HasOne("School.Domain.ModelsDb.CategoryDb", "CategoryDb")
                        .WithMany("Products")
                        .HasForeignKey("CategoryDbId");

                    b.HasOne("School.Domain.ModelsDb.OrdersDb", "OderDb")
                        .WithMany("Products")
                        .HasForeignKey("OderDbId");

                    b.HasOne("School.Domain.ModelsDb.PictureProductDb", "PictureProduc")
                        .WithMany("Products")
                        .HasForeignKey("PictureProducId");

                    b.Navigation("CategoryDb");

                    b.Navigation("OderDb");

                    b.Navigation("PictureProduc");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.RequestDb", b =>
                {
                    b.HasOne("School.Domain.ModelsDb.UserDb", "UserDb")
                        .WithMany("requestDbs")
                        .HasForeignKey("UserDbId");

                    b.Navigation("UserDb");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.CategoryDb", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.OrdersDb", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.PictureProductDb", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("School.Domain.ModelsDb.UserDb", b =>
                {
                    b.Navigation("ordersDb");

                    b.Navigation("requestDbs");
                });
#pragma warning restore 612, 618
        }
    }
}
