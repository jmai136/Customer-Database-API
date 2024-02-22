﻿// <auto-generated />
using System;
using CustomerDatabaseAPI.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerDatabaseAPI.Server.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.CALL.Call", b =>
                {
                    b.Property<int>("CallID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallID"));

                    b.Property<DateTime>("CallDurationEndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CallDurationStartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CallNotesID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerSupportRepresentativeID")
                        .HasColumnType("int");

                    b.HasKey("CallID");

                    b.HasIndex("CallNotesID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerSupportRepresentativeID");

                    b.ToTable("Call", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.CALL.CallNotes", b =>
                {
                    b.Property<int>("CallNotesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallNotesID"));

                    b.Property<string>("CallNotesDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsResolved")
                        .HasColumnType("tinyint");

                    b.HasKey("CallNotesID");

                    b.ToTable("CallNotes", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"));

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyIndustry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Company", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.CompanyInfo", b =>
                {
                    b.Property<int>("CompanyInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyInfoID"));

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<int?>("EmailID")
                        .HasColumnType("int");

                    b.Property<int?>("PhoneNumberID")
                        .HasColumnType("int");

                    b.HasKey("CompanyInfoID");

                    b.HasIndex("AddressID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("EmailID");

                    b.HasIndex("PhoneNumberID");

                    b.ToTable("CompanyInfo", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.PERSON.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PersonID");

                    b.ToTable("Person", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.PERSON.PersonInfo", b =>
                {
                    b.Property<int>("PersonInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonInfoID"));

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("EmailID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<int?>("PhoneNumberID")
                        .HasColumnType("int");

                    b.HasKey("PersonInfoID");

                    b.HasIndex("AddressID");

                    b.HasIndex("EmailID");

                    b.HasIndex("PersonID");

                    b.HasIndex("PhoneNumberID");

                    b.ToTable("PersonInfo", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("PersonId");

                    b.ToTable("Customer", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.CustomerSupportRepresentative", b =>
                {
                    b.Property<int>("CustomerSupportRepresentativeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerSupportRepresentativeID"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("CustomerSupportRepresentativeID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Csr", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("AddressLineOne")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AddressLineTwo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AddressID");

                    b.ToTable("Address", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.Email", b =>
                {
                    b.Property<int>("EmailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmailID"));

                    b.Property<string>("EmailCharacters")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.HasKey("EmailID");

                    b.ToTable("Email", "CustomerDatabase");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneNumberID"));

                    b.Property<string>("PhoneNumberDigits")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("PhoneNumberID");

                    b.ToTable("PhoneNumber", "CustomerDatabase");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.CALL.Call", b =>
                {
                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.CALL.CallNotes", "CallNotes")
                        .WithMany("Calls")
                        .HasForeignKey("CallNotesID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.Recipients.Customer", "Customer")
                        .WithMany("Calls")
                        .HasForeignKey("CustomerId");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.Recipients.CustomerSupportRepresentative", "CustomerSupportRepresentative")
                        .WithMany("Calls")
                        .HasForeignKey("CustomerSupportRepresentativeID");

                    b.Navigation("CallNotes");

                    b.Navigation("Customer");

                    b.Navigation("CustomerSupportRepresentative");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.CompanyInfo", b =>
                {
                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.Address", "Address")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("AddressID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.Company", "Company")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("CompanyID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.Email", "Email")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("EmailID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.PhoneNumber", "PhoneNumber")
                        .WithMany("CompanyInfos")
                        .HasForeignKey("PhoneNumberID");

                    b.Navigation("Address");

                    b.Navigation("Company");

                    b.Navigation("Email");

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.PERSON.PersonInfo", b =>
                {
                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.Address", "Address")
                        .WithMany("PersonInfos")
                        .HasForeignKey("AddressID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.Email", "Email")
                        .WithMany("PersonInfos")
                        .HasForeignKey("EmailID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.PERSON.Person", "Person")
                        .WithMany("PersonInfos")
                        .HasForeignKey("PersonID");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.General.PhoneNumber", "PhoneNumber")
                        .WithMany("PersonInfos")
                        .HasForeignKey("PhoneNumberID");

                    b.Navigation("Address");

                    b.Navigation("Email");

                    b.Navigation("Person");

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.Customer", b =>
                {
                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.PERSON.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.CustomerSupportRepresentative", b =>
                {
                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.Company", "Company")
                        .WithMany("CustomerSupportRepresentatives")
                        .HasForeignKey("CompanyId");

                    b.HasOne("CustomerDatabaseAPI.Server.Models.Actors.PERSON.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Company");

                    b.Navigation("Person");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.CALL.CallNotes", b =>
                {
                    b.Navigation("Calls");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.COMPANY.Company", b =>
                {
                    b.Navigation("CompanyInfos");

                    b.Navigation("CustomerSupportRepresentatives");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.PERSON.Person", b =>
                {
                    b.Navigation("PersonInfos");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.Customer", b =>
                {
                    b.Navigation("Calls");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.Actors.Recipients.CustomerSupportRepresentative", b =>
                {
                    b.Navigation("Calls");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.Address", b =>
                {
                    b.Navigation("CompanyInfos");

                    b.Navigation("PersonInfos");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.Email", b =>
                {
                    b.Navigation("CompanyInfos");

                    b.Navigation("PersonInfos");
                });

            modelBuilder.Entity("CustomerDatabaseAPI.Server.Models.General.PhoneNumber", b =>
                {
                    b.Navigation("CompanyInfos");

                    b.Navigation("PersonInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
