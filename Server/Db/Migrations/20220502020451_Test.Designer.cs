﻿// <auto-generated />
using System;
using HogeBlazor.Server.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HogeBlazor.Server.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220502020451_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HogeBlazor.Shared.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0102f709-1dd7-40de-af3d-23598c6bbd1f"),
                            ImageUrl = "https://ih1.redbubble.net/image.1062161969.4889/mug,travel,x1000,center-pad,1000x1000,f8f8f8.u2.jpg",
                            Name = "Travel Mug",
                            Price = 11.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("ac7de2dc-049c-4328-ab06-6cde3ebe8aa7"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063377597.4889/ur,mug_lifestyle,square,1000x1000.u2.jpg",
                            Name = "Classic Mug",
                            Price = 22.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("d26384cb-64b9-4aca-acb0-4ebb8fc53ba2"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ra,vneck,x1900,101010:01c5ca27c6,front-c,160,70,1000,1000-bg,f8f8f8.u2.jpg",
                            Name = "Code Maze Logo T-Shirt",
                            Price = 20.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("b47d4c3c-3e29-49b9-b6be-28e5ee4625be"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodie,mens,101010:01c5ca27c6,front,square_three_quarter,x1000-bg,f8f8f8.1u2.jpg",
                            Name = "Pullover Hoodie",
                            Price = 30.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("54b2f952-b63e-4cad-8b38-c09955fe4c62"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ssrco,mhoodiez,mens,101010:01c5ca27c6,front,square_three_quarter,1000x1000-bg,f8f8f8.u2.jpg",
                            Name = "Fitted Scoop T-Shirt",
                            Price = 40.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("83e0aa87-158f-4e5f-a8f7-e5a98d13e3a5"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063364659.4889/ra,fitted_scoop,x2000,101010:01c5ca27c6,front-c,160,143,1000,1000-bg,f8f8f8.u2.jpg",
                            Name = "Zipped Hoodie",
                            Price = 55.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("488aaa0e-aa7e-4820-b4e9-5715f0e5186e"),
                            ImageUrl = "https://ih1.redbubble.net/image.1062161956.4889/icr,iphone_11_soft,back,a,x1000-pad,1000x1000,f8f8f8.u2.jpg",
                            Name = "iPhone Case & Cover",
                            Price = 25.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("4e693871-788d-4db4-89e5-dd7678db975e"),
                            ImageUrl = "https://ih1.redbubble.net/image.1062161956.4889/icr,samsung_galaxy_s10_snap,back,a,x1000-pad,1000x1000,f8f8f8.1u2.jpg",
                            Name = "Case & Skin for Samsung Galaxy",
                            Price = 35.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("2d3c2abe-85ec-4d1e-9fef-9b4bfea5f459"),
                            ImageUrl = "https://ih1.redbubble.net/image.1063329780.4889/mwo,x1000,ipad_2_snap-pad,1000x1000,f8f8f8.u2.jpg",
                            Name = "iPad Case & Skin",
                            Price = 45.0,
                            Supplier = "Code Maze"
                        },
                        new
                        {
                            Id = new Guid("d1f22836-6342-480a-be2f-035eeb010fd0"),
                            ImageUrl = "https://ih1.redbubble.net/image.1062161997.4889/clkc,bamboo,white,1000x1000-bg,f8f8f8.u2.jpg",
                            Name = "Wall Clock",
                            Price = 25.0,
                            Supplier = "Code Maze"
                        });
                });

            modelBuilder.Entity("HogeBlazor.Shared.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HogeBlazor.Shared.Models.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<LocalDate>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.Property<LocalTime>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new NodaTime.LocalDate(2022, 5, 18),
                            Summary = "雨",
                            TemperatureC = 15,
                            Time = new NodaTime.LocalTime(12, 34, 56)
                        },
                        new
                        {
                            Id = 2,
                            Date = new NodaTime.LocalDate(2022, 5, 18),
                            Summary = "晴れのち曇",
                            TemperatureC = 18,
                            Time = new NodaTime.LocalTime(12, 34, 56)
                        },
                        new
                        {
                            Id = 3,
                            Date = new NodaTime.LocalDate(2022, 5, 18),
                            Summary = "晴",
                            TemperatureC = 22,
                            Time = new NodaTime.LocalTime(12, 34, 56)
                        },
                        new
                        {
                            Id = 4,
                            Date = new NodaTime.LocalDate(2022, 5, 18),
                            Summary = "台風",
                            TemperatureC = 26,
                            Time = new NodaTime.LocalTime(12, 34, 56)
                        },
                        new
                        {
                            Id = 5,
                            Date = new NodaTime.LocalDate(2022, 5, 18),
                            Summary = "曇",
                            TemperatureC = 21,
                            Time = new NodaTime.LocalTime(12, 34, 56)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "617bb7f9-087d-42f1-9173-17d68cf54719",
                            ConcurrencyStamp = "0ec2e517-05c7-4f9c-9f40-4517dbcfb01a",
                            Name = "Viewer",
                            NormalizedName = "VIEWER"
                        },
                        new
                        {
                            Id = "3e244ceb-f35e-445b-8f8a-ac1d8a35d017",
                            ConcurrencyStamp = "a2898ca4-183f-4486-a9bb-81dc4ed5cde4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HogeBlazor.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HogeBlazor.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HogeBlazor.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HogeBlazor.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}