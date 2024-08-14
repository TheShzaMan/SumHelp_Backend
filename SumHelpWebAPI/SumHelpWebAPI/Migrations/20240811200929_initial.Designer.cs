﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SumHelpWebAPI.Data;

#nullable disable

namespace SumHelpWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240811200929_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SumHelpWebAPI.Models.ErrorLogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DeviceInfo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OccurredAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.ReportModel", b =>
                {
                    b.Property<Guid>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdminResponse")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ResolvedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ScreenshotUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.SettingsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("NotificationsEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.UserModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LanguagePreference")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RevenueCatUserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SubscriptionExpiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SubscriptionStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.UserQuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("varchar(4000)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("UserQuestions");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.ErrorLogModel", b =>
                {
                    b.HasOne("SumHelpWebAPI.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.SettingsModel", b =>
                {
                    b.HasOne("SumHelpWebAPI.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SumHelpWebAPI.Models.UserQuestionModel", b =>
                {
                    b.HasOne("SumHelpWebAPI.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}