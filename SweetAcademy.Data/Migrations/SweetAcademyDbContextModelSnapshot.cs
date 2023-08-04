﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetAcademy.Data;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    [DbContext(typeof(SweetAcademyDbContext))]
    partial class SweetAcademyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserTraining", b =>
                {
                    b.Property<Guid>("ParticipatorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("ParticipatorsId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("ApplicationUserTraining");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "df94bcd6-62ee-46f1-a089-0576b12308bf",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@ADMIN.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEHXuw6dYlxC8AEJ5dq817hzjCU/O72xLYs+NeKUXL/Rdikx4mt6Q3+3jzAhARG4NEA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "EF2DAKHPWV6KTXCJF4JR2RQMHEXPPGQ3",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.bg"
                        },
                        new
                        {
                            Id = new Guid("21d6dffe-e209-4dcc-9fa9-08db92b169a9"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f420ec05-4560-49a1-a22a-3a7c6b0ffc9a",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "IP@CUSTOMER.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEO1XTr6PzJ1+1+fdYOEB+Dq8GcV5kClGxOY90gYEs0MmzeRZA2G7eGL205oEaCYbcg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2WCQ3I2BZ2DU4YJT62ZMCHKVUCO2PKGL",
                            TwoFactorEnabled = false,
                            UserName = "ip@customer.bg"
                        });
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Chef", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxPerTrainingForStudent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Chef");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"),
                            Active = true,
                            ApplicationUserId = new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"),
                            FullName = "Steffy Cheffy",
                            PhoneNumber = 899999999,
                            TaxPerTrainingForStudent = 30.50m
                        });
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            Name = "Sugar",
                            Price = 0.20m,
                            Unit = "50 g."
                        },
                        new
                        {
                            Id = 2,
                            Active = false,
                            Name = "Butter",
                            Price = 6.99m,
                            Unit = "250 g."
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Name = "Chocolate",
                            Price = 3.50m,
                            Unit = "90 g."
                        },
                        new
                        {
                            Id = 4,
                            Active = false,
                            Name = "Milk",
                            Price = 1.5m,
                            Unit = "500 ml"
                        });
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StepsJson")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Description = "Bake an impressive dinner party dessert with minimum fuss – these chocolate puddings, also known as chocolate fondant or lava cake, have a lovely gooey center",
                            ImageUrl = "https://img.freepik.com/free-vector/chocolate-lava-cake-with-raspberry-sticker-isolated-white-background_1308-65607.jpg?w=740&t=st=1690710465~exp=1690711065~hmac=c96a6d3712a020c5968f3facf16b2b30de62319e54a40295bdf134c02fef733a",
                            Name = "Lava Cake",
                            StepsJson = "[\"Heat oven to 200C/180C fan/gas 6. Butter 6 dariole moulds or basins well and place on a baking tray.\",\"Carefully run a knife around the edge of each pudding, then turn out onto serving plates and serve with single cream.\"]"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Description = "Dairy-free and egg-free, this delicious ice cream is surprisingly rich and indulgent. Use whatever add-ins you like in this dairy-free ice cream; a fantastic base recipe that's super easy!",
                            ImageUrl = "https://img.freepik.com/free-vector/ice-cream-cone-cartoon-icon-illustration-sweet-food-icon-concept-isolated-flat-cartoon-style_138676-2924.jpg?w=740&t=st=1690915084~exp=1690915684~hmac=541a6d2f00afd0f44bf7033fbbb68151944f853d57559807362364812e0bef60",
                            Name = "VEGAN ICE CREAM",
                            StepsJson = "[\"Blend: In a blender, add all ingredients and blend on high until thick and creamy, 1-2 min. Transfer mixture to an airtight container and chill 2-4 hours.\",\"Freeze: May serve immediately for a frozen custard-like texture that's ultra creamy, smooth, and soft. Otherwise, transfer ice cream to an airtight container and freeze 30-60 minutes for a firmer texture. If frozen much longer, it will need thaw time at room temp before serving (actual thaw time depends on your room temp.)\"]"
                        });
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.RecipeProduct", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("RecipeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("RecipesProducts");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            ProductId = 1,
                            Quantity = 5
                        },
                        new
                        {
                            RecipeId = 1,
                            ProductId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            RecipeId = 1,
                            ProductId = 3,
                            Quantity = 4
                        },
                        new
                        {
                            RecipeId = 2,
                            ProductId = 1,
                            Quantity = 5
                        },
                        new
                        {
                            RecipeId = 2,
                            ProductId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            RecipeId = 2,
                            ProductId = 3,
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("ChefId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OpenSeats")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("ApplicationUserTraining", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ParticipatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetAcademy.Data.Models.Training", null)
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Chef", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", "User")
                        .WithOne("Chef")
                        .HasForeignKey("SweetAcademy.Data.Models.Chef", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Order", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.Training", "OrderedTraining")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetAcademy.Data.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderedTraining");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.RecipeProduct", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.Product", "Product")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetAcademy.Data.Models.Recipe", "Recipe")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Training", b =>
                {
                    b.HasOne("SweetAcademy.Data.Models.Chef", "Trainer")
                        .WithMany("CouchingSession")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SweetAcademy.Data.Models.Recipe", "Recipe")
                        .WithMany("Trainings")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Chef");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Chef", b =>
                {
                    b.Navigation("CouchingSession");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Product", b =>
                {
                    b.Navigation("RecipeProducts");
                });

            modelBuilder.Entity("SweetAcademy.Data.Models.Recipe", b =>
                {
                    b.Navigation("RecipeProducts");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
