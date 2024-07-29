﻿// <auto-generated />
using System;
using BackendApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend_app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240726193224_InitialCreaTe")]
    partial class InitialCreaTe
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BackendApp.Models.CategoryModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("CategoryModel");
                });

            modelBuilder.Entity("BackendApp.Models.LocationModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("LocationModel");
                });

            modelBuilder.Entity("BackendApp.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TestId");

                    b.ToTable("PostModel");
                });

            modelBuilder.Entity("BackendApp.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TestModel");
                });

            modelBuilder.Entity("BackendApp.Models.TestOptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TestModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestModelId");

                    b.ToTable("TestOptions");
                });

            modelBuilder.Entity("BackendApp.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Bio")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(355)
                        .HasColumnType("varchar(355)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserImgUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("BackendApp.Models.PostModel", b =>
                {
                    b.HasOne("BackendApp.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("BackendApp.Models.LocationModel", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("BackendApp.Models.UserModel", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("BackendApp.Models.TestModel", "Test")
                        .WithMany()
                        .HasForeignKey("TestId");

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("Teacher");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("BackendApp.Models.TestOptions", b =>
                {
                    b.HasOne("BackendApp.Models.TestModel", null)
                        .WithMany("Options")
                        .HasForeignKey("TestModelId");
                });

            modelBuilder.Entity("BackendApp.Models.TestModel", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
