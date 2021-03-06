﻿// <auto-generated />
using System;
using JMS.Entity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace JMS.Entity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200802154349_CreatedDate")]
    partial class CreatedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("JMS.Entity.Entities.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("AffiliationNo")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

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

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserName");

                    b.HasIndex("TenantId", "UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JMS.Entity.Entities.Contributor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AffiliationNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ContributerRole")
                        .HasColumnType("integer");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("ORCIDiD")
                        .HasColumnType("text");

                    b.Property<long>("SubmissionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("JMS.Entity.Entities.JournalSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TenantId", "Key")
                        .IsUnique();

                    b.ToTable("JournalSettings");
                });

            modelBuilder.Entity("JMS.Entity.Entities.Submission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CreateStep")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EditorComment")
                        .HasColumnType("text");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prefix")
                        .HasColumnType("text");

                    b.Property<int>("SubmissionStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Subtitle")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Submission");
                });

            modelBuilder.Entity("JMS.Entity.Entities.SubmisssionFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ArticleComponentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FileId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<long>("SubmissionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UploadedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArticleComponentId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("SubmisssionFile");
                });

            modelBuilder.Entity("JMS.Entity.Entities.SystemSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("JMS.Entity.Entities.Tenant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("Added")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstLine")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("JournalLogo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JournalName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JournalPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JournalTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastLine")
                        .HasColumnType("text");

                    b.Property<string>("OnlineISSN")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("PrintISSN")
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("JournalPath")
                        .IsUnique();

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("JMS.Entity.Entities.TenantArticleComponent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<long?>("TenantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantArticleComponent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ProviderKey", "LoginProvider");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "Name", "LoginProvider");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("JMS.Entity.Entities.ApplicationUser", b =>
                {
                    b.HasOne("JMS.Entity.Entities.Tenant", "Tenant")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("TenantId");
                });

            modelBuilder.Entity("JMS.Entity.Entities.Contributor", b =>
                {
                    b.HasOne("JMS.Entity.Entities.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JMS.Entity.Entities.JournalSetting", b =>
                {
                    b.HasOne("JMS.Entity.Entities.Tenant", "Tenant")
                        .WithMany("JournalSettings")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JMS.Entity.Entities.Submission", b =>
                {
                    b.HasOne("JMS.Entity.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JMS.Entity.Entities.SubmisssionFile", b =>
                {
                    b.HasOne("JMS.Entity.Entities.TenantArticleComponent", "TenantArticleComponent")
                        .WithMany()
                        .HasForeignKey("ArticleComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JMS.Entity.Entities.Submission", "Submission")
                        .WithMany()
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JMS.Entity.Entities.TenantArticleComponent", b =>
                {
                    b.HasOne("JMS.Entity.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");
                });
#pragma warning restore 612, 618
        }
    }
}
