﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using videostore_be.Models;

#nullable disable

namespace videostorebe.Migrations
{
    [DbContext(typeof(VideoStoreContext))]
    partial class VideoStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("videostore_be.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("videostore_be.Models.Videos", b =>
                {
                    b.Property<int>("VideosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideosId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<decimal?>("RentalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideosId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("videostore_be.Models.VideosCustomer", b =>
                {
                    b.Property<int>("VideosCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideosCustomerId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VideosId")
                        .HasColumnType("int");

                    b.Property<int>("copyCount")
                        .HasColumnType("int");

                    b.HasKey("VideosCustomerId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VideosId");

                    b.ToTable("VideosCustomer");
                });

            modelBuilder.Entity("videostore_be.Models.VideosCustomer", b =>
                {
                    b.HasOne("videostore_be.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("videostore_be.Models.Videos", "Videos")
                        .WithMany()
                        .HasForeignKey("VideosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
