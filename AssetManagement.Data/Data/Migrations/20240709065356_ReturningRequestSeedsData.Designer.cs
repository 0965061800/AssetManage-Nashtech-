﻿// <auto-generated />
using System;
using AssetManagement.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetManagement.Data.Data.Migrations
{
    [DbContext(typeof(AssetManagementDbContext))]
    [Migration("20240709065356_ReturningRequestSeedsData")]
    partial class ReturningRequestSeedsData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssetManagement.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPasswordChanged")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastUpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("StaffCode")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InstalledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("AssignedToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("AssignedById");

                    b.HasIndex("AssignedToId");

                    b.ToTable("Assignment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab64f62d-71a0-4520-9522-2bbbebbc1c7b"),
                            AssetId = new Guid("81436c8d-4090-4abf-a926-14d061f1f9c9"),
                            AssignedById = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2849),
                            AssignedToId = new Guid("48bc2207-ec50-455d-99e4-990995f809e0"),
                            LastUpdated = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2849),
                            Note = "Assignment 11",
                            State = 5
                        },
                        new
                        {
                            Id = new Guid("1f01cf21-4609-41d8-be82-446f42f6dd68"),
                            AssetId = new Guid("f673f337-c449-4ff1-97cd-366b79cf3a63"),
                            AssignedById = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2855),
                            AssignedToId = new Guid("ede0c1cd-5d7e-422c-a787-8f473c45123b"),
                            LastUpdated = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2856),
                            Note = "Assignment 12",
                            State = 5
                        },
                        new
                        {
                            Id = new Guid("26c42587-dd3c-4546-a1e5-e286ca0bc2a2"),
                            AssetId = new Guid("f0dff85d-6cc7-496b-8437-40b50298e62c"),
                            AssignedById = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2860),
                            AssignedToId = new Guid("256a9cef-7479-4563-a104-8b310e16ffe0"),
                            LastUpdated = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2861),
                            Note = "Assignment 13",
                            State = 5
                        },
                        new
                        {
                            Id = new Guid("a50232d9-c3da-44d6-81a1-da151617d805"),
                            AssetId = new Guid("0eab77a8-ed89-4483-9d98-6ccafa74d450"),
                            AssignedById = new Guid("2c484448-b14e-46f3-957e-a8719f14bbd6"),
                            AssignedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2866),
                            AssignedToId = new Guid("2450bc08-8b39-41cf-90e9-7b10510c557e"),
                            LastUpdated = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2866),
                            Note = "Assignment 14",
                            State = 5
                        });
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.ReturningRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AcceptedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcceptedByUserId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("ReturningRequest");

                    b.HasData(
                        new
                        {
                            Id = new Guid("310d7095-14ab-4db5-80e8-342edade11ed"),
                            AcceptedByUserId = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignmentId = new Guid("ab64f62d-71a0-4520-9522-2bbbebbc1c7b"),
                            ReturnedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2903),
                            State = 1
                        },
                        new
                        {
                            Id = new Guid("a1746cd6-d446-4304-931c-dc135c70fa1a"),
                            AcceptedByUserId = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignmentId = new Guid("1f01cf21-4609-41d8-be82-446f42f6dd68"),
                            ReturnedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2909),
                            State = 1
                        },
                        new
                        {
                            Id = new Guid("46702563-2808-41b1-892d-3b7b26d9737b"),
                            AcceptedByUserId = new Guid("4c196276-54f0-48ae-acc9-abeb0cb598f5"),
                            AssignmentId = new Guid("26c42587-dd3c-4546-a1e5-e286ca0bc2a2"),
                            ReturnedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2913),
                            State = 1
                        },
                        new
                        {
                            Id = new Guid("8621630b-f5fe-4861-8b70-f0617d08668e"),
                            AcceptedByUserId = new Guid("2c484448-b14e-46f3-957e-a8719f14bbd6"),
                            AssignmentId = new Guid("a50232d9-c3da-44d6-81a1-da151617d805"),
                            ReturnedDate = new DateTime(2024, 7, 9, 13, 53, 55, 739, DateTimeKind.Local).AddTicks(2917),
                            State = 1
                        });
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Role", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bbf66a4-da08-4b87-bdb2-1502e38562f3"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("5fc71af5-0216-402b-a5cb-ba17701e2fa3"),
                            Name = "Staff",
                            NormalizedName = "STAFF"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("nvarchar(34)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.UserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasIndex("RoleId");

                    b.HasDiscriminator().HasValue("UserRole");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Category", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Domain.Entities.AppUser", "AssignedByUser")
                        .WithMany("AssignedByAssignments")
                        .HasForeignKey("AssignedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AssetManagement.Domain.Entities.AppUser", "AssignedToUser")
                        .WithMany("AssignedToAssignments")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("AssignedByUser");

                    b.Navigation("AssignedToUser");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.ReturningRequest", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.AppUser", "AcceptedByUser")
                        .WithMany()
                        .HasForeignKey("AcceptedByUserId");

                    b.HasOne("AssetManagement.Domain.Entities.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcceptedByUser");

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("AssetManagement.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Domain.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("AssignedByAssignments");

                    b.Navigation("AssignedToAssignments");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Asset", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Category", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetManagement.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
