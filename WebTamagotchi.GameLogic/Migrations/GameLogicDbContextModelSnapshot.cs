﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebTamagotchi.GameLogic;

#nullable disable

namespace WebTamagotchi.GameLogic.Migrations
{
    [DbContext(typeof(GameLogicDbContext))]
    partial class GameLogicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Bathroom", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Cleanliness")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bathrooms");

                    b.HasData(
                        new
                        {
                            Id = "0100efb3-a489-4dc5-b33f-3f4acd5c0766",
                            Cleanliness = 20,
                            Experience = 20,
                            Name = "Standard Bathroom"
                        });
                });

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Bedroom", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Energy")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bedrooms");

                    b.HasData(
                        new
                        {
                            Id = "c2a994dc-77f2-4733-8b10-73b01b787695",
                            Energy = 20,
                            Experience = 20,
                            Name = "Standard Bedroom"
                        });
                });

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Food", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Dirtiness")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("IconJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Satiety")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = "905e8cdf-8e84-441b-98d2-cb9b3d98c548",
                            Dirtiness = 6,
                            Experience = 10,
                            IconJson = "icon",
                            Name = "Apple",
                            Satiety = 10
                        },
                        new
                        {
                            Id = "2486f252-4ee6-4805-82ad-f723bbebe670",
                            Dirtiness = 12,
                            Experience = 20,
                            IconJson = "icon",
                            Name = "Soup",
                            Satiety = 26
                        });
                });

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Dirtiness")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("Fun")
                        .HasColumnType("integer");

                    b.Property<int>("Hunger")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tiredness")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = "cf619653-3c19-49a1-9790-23ba30458dad",
                            Dirtiness = 10,
                            Experience = 20,
                            Fun = 10,
                            Hunger = 16,
                            Name = "TestGame",
                            Tiredness = 20
                        });
                });

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bore")
                        .HasColumnType("integer");

                    b.Property<int>("Dirtiness")
                        .HasColumnType("integer");

                    b.Property<int>("ExpToLevelUp")
                        .HasColumnType("integer");

                    b.Property<int>("Hunger")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerId")
                        .HasColumnType("text");

                    b.Property<int>("Tiredness")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("WebTamagotchi.Identity.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebTamagotchi.GameLogic.Models.Pet", b =>
                {
                    b.HasOne("WebTamagotchi.Identity.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });
#pragma warning restore 612, 618
        }
    }
}
