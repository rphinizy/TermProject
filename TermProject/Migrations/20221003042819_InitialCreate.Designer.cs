﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TermProject.Models;

namespace TermProject.Migrations
{
    [DbContext(typeof(DogContext))]
    [Migration("20221003042819_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TermProject.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("DogId");

                    b.HasIndex("GenderId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Age = 2,
                            Breed = "Bulldog",
                            GenderId = "F",
                            Name = "Daisy",
                            Weight = 45
                        },
                        new
                        {
                            DogId = 2,
                            Age = 6,
                            Breed = "Mix",
                            GenderId = "M",
                            Name = "Fido",
                            Weight = 30
                        },
                        new
                        {
                            DogId = 3,
                            Age = 1,
                            Breed = "Labrador",
                            GenderId = "M",
                            Name = "Bingo",
                            Weight = 60
                        },
                        new
                        {
                            DogId = 4,
                            Age = 8,
                            Breed = "Husky",
                            GenderId = "M",
                            Name = "Balto",
                            Weight = 55
                        });
                });

            modelBuilder.Entity("TermProject.Models.Gender", b =>
                {
                    b.Property<string>("GenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            GenderId = "M",
                            Sex = "Male"
                        },
                        new
                        {
                            GenderId = "F",
                            Sex = "Female"
                        });
                });

            modelBuilder.Entity("TermProject.Models.Dog", b =>
                {
                    b.HasOne("TermProject.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
