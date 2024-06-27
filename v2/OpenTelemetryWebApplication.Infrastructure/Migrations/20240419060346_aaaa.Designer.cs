﻿// <auto-generated />
using System;
using OpenTelemetryWebApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace OpenTelemetryWebApplication.Infrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20240419060346_aaaa")]
    partial class aaaa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Books_CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("BookId");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BooksOrder", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("Books_Orders", (string)null);
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Book", b =>
                {
                    b.HasOne("OpenTelemetryWebApplication.Domain.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Inventory", b =>
                {
                    b.HasOne("OpenTelemetryWebApplication.Domain.Models.Book", "Book")
                        .WithOne("Inventory")
                        .HasForeignKey("OpenTelemetryWebApplication.Domain.Models.Inventory", "Id")
                        .IsRequired()
                        .HasConstraintName("FK_Inventory_Books");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BooksOrder", b =>
                {
                    b.HasOne("OpenTelemetryWebApplication.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK_Books");

                    b.HasOne("OpenTelemetryWebApplication.Domain.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders");
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Book", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("OpenTelemetryWebApplication.Domain.Models.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
