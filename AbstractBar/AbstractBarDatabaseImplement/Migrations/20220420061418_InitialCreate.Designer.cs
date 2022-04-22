﻿// <auto-generated />
using System;
using AbstractBarDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbstractBarDatabaseImplement.Migrations
{
    [DbContext(typeof(AbstractBarDatabase))]
    [Migration("20220420061418_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Cocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CocktailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.CocktailComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CocktailId")
                        .HasColumnType("int");

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("ComponentId");

                    b.ToTable("CocktailComponents");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Component", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComponentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("CocktailId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CocktailId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.CocktailComponent", b =>
                {
                    b.HasOne("AbstractBarDatabaseImplement.Models.Cocktail", "Cocktail")
                        .WithMany("CocktailComponents")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbstractBarDatabaseImplement.Models.Component", "Component")
                        .WithMany("CocktailComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cocktail");

                    b.Navigation("Component");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("AbstractBarDatabaseImplement.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbstractBarDatabaseImplement.Models.Cocktail", "Cocktail")
                        .WithMany("Orders")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Cocktail");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Cocktail", b =>
                {
                    b.Navigation("CocktailComponents");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AbstractBarDatabaseImplement.Models.Component", b =>
                {
                    b.Navigation("CocktailComponents");
                });
#pragma warning restore 612, 618
        }
    }
}
