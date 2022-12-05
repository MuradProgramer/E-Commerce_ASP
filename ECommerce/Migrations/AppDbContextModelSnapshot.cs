﻿// <auto-generated />
using System;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Models.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Smartphone"
                        });
                });

            modelBuilder.Entity("ECommerce.Models.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "128 GB Black",
                            Price = 1399.99,
                            Title = "iPhone 11"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "128 GB 5G Blue",
                            Price = 899.99000000000001,
                            Title = "Samsung Galaxy A53"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "4/64 GB Star Blue",
                            Price = 459.99000000000001,
                            Title = "Xiaomi Redmi Note 11"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "128 GB Midnight",
                            Price = 1999.99,
                            Title = "iPhone 13"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "6/128 GB Lite Pink",
                            Price = 899.99000000000001,
                            Title = "Xiaomi 12 Lite"
                        });
                });

            modelBuilder.Entity("ECommerce.Models.Concrete.Product", b =>
                {
                    b.HasOne("ECommerce.Models.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Models.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
