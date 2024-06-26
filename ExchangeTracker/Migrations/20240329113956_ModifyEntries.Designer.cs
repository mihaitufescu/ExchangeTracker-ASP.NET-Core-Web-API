﻿// <auto-generated />
using System;
using ExchangeTracker.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeTracker.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240329113956_ModifyEntries")]
    partial class ModifyEntries
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.CurrencyEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Id_Currency")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Id_Currency");

                    b.ToTable("CurrencyEntry");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.CurrencyTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Currency")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<DateTime>("LowerBound_Date")
                        .HasColumnType("date");

                    b.Property<DateTime>("UpperBound_Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Id_Currency");

                    b.HasIndex("Id_User");

                    b.ToTable("CurrencyTrack");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.CurrencyEntry", b =>
                {
                    b.HasOne("ExchangeTracker.DAL.DBO.Currency", "Currency")
                        .WithMany("Entries")
                        .HasForeignKey("Id_Currency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.CurrencyTrack", b =>
                {
                    b.HasOne("ExchangeTracker.DAL.DBO.Currency", "Currency")
                        .WithMany("Tracks")
                        .HasForeignKey("Id_Currency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExchangeTracker.DAL.DBO.User", "User")
                        .WithMany("Tracks")
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.Currency", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("ExchangeTracker.DAL.DBO.User", b =>
                {
                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
